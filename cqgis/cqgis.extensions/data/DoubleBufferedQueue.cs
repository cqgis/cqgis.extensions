using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace cqgis.extensions.data
{

    /// <summary>
    /// cqgis:双缓冲队列
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DoubleBufferedQueue<T> : IDisposable
    {
        private readonly int _millisecond;

        private readonly Queue<T> _queue1 = new Queue<T>();
        private readonly Queue<T> _queue2 = new Queue<T>();
        private readonly ManualResetEvent _equeueLock = new ManualResetEvent(true);
        private readonly ManualResetEvent _dequeuelock = new ManualResetEvent(false);
        private readonly AutoResetEvent _autoReset = new AutoResetEvent(true);
        private volatile Queue<T> _currentQueue;
        public DoubleBufferedQueue(int millisecond = 0)
        {
            _millisecond = millisecond;
            _currentQueue = _queue1;


            Task.Factory.StartNew(BackgroundWorker_DoWork, TaskCreationOptions.LongRunning);

        }

        private bool _isexit = false;

        /// <summary>
        /// cqgis:消费者方法
        /// </summary>
        public Action<Queue<T>> ConsumerAction { get; set; }

        /// <summary>
        /// cqgis:消费者方法，异步
        /// </summary>
        public Func<Queue<T>, Task> ConsumerActionAsync { get; set; }


        private async void BackgroundWorker_DoWork()
        {
            while (true)
            {
                var readQueue = this.GetDequeue();
                ConsumerAction?.Invoke(readQueue);

                if (ConsumerActionAsync != null)
                {
                    await ConsumerActionAsync(readQueue); //task
                }

                if (_millisecond > 0)
                    await Task.Delay(_millisecond);

                if (_isexit)
                    return;
            }

        }

        /// <summary>
        /// cqgis:入队列
        /// </summary>
        /// <param name="item"></param>
        /// <param name="action">入队列后，要执行的默认操作</param>
        public void Equeue(T item, Action<T> action = null)
        {
            this._dequeuelock.WaitOne();
            this._equeueLock.Reset();
            _currentQueue.Enqueue(item);
            action?.Invoke(item);
            _equeueLock.Set();
            _autoReset.Set();
        }
        private Queue<T> GetDequeue()
        {
            this._autoReset.WaitOne();
            this._dequeuelock.Reset();
            this._equeueLock.WaitOne();
            var readQueue = _currentQueue;
            _currentQueue = (_currentQueue == _queue1) ? _queue2 : _queue1;
            this._dequeuelock.Set();
            return readQueue;
        }
        public void Dispose()
        {
            _dequeuelock.Reset();
            ConsumerAction?.Invoke(_queue1);
            ConsumerAction?.Invoke(_queue2);

            _isexit = true;
        }
    }
}