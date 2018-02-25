using System;

// ReSharper disable once CheckNamespace
namespace cqgis.extensions
{

    /// <summary>
    /// cqgis:事件的基类
    /// </summary>
    public abstract class EventBase
    {
    }
     
    /// <summary>
    /// cqgis:程序加载的信息
    /// </summary>
    public class LoadingEvent : EventBase
    {
        public LoadingEvent(bool isloading, string text = "")
        {
            IsLoading = isloading;
            this.Text = text;
        }

        public bool IsLoading { get; set; }

        public string Text { get; set; }
    }


    /// <summary>
    /// cqgis:程序弹出消息框显示的信息
    /// </summary>

    public class MessageBoxInfoEvent : EventBase
    {
        public string Message { get; }

        /// <summary>
        /// cqgis: 1 详情  2 错误
        /// </summary>
        public MessageInfoType Type { get; }

        /// <summary>
        /// cqgis:程序弹出消息框显示的信息
        /// </summary>
        /// <param name="message">消息内容</param>
        /// <param name="type">1 详情  2 错误 </param>
        public MessageBoxInfoEvent(string message, MessageInfoType type = MessageInfoType.Info)
        {
            Message = message;
            Type = type;
        }

        [Flags]
        public enum MessageInfoType
        {
            None = 0,
            Info = 1,
            Warning = 2,
            Error = 3,
        }
    }
}
