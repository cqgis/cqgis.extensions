using System;

namespace cqgis.extensions.data
{

    /// <summary>
    ///cqgis: 返回的消息 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ServiceMessage<T>
    {
        /// <summary>
        ///cqgis: 是否返回了正确的结果
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// cqgis:如果 <see cref="Success"/>为True, 此字段包含了结果
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        ///cqgis: 如果 <see cref="Success"/>为False, 此字段包含异常的信息内容
        /// </summary>
        public string ErrorInfo { get; set; }


        /// <summary>
        /// cqgis:服务返回的消息
        /// </summary>
        public ServiceMessage() { }


        /// <summary>
        /// cqgis:服务返回的消息
        /// </summary>
        public ServiceMessage(T data)
        {
            this.Success = true;
            this.Data = data;
        }


        /// <summary>
        /// cqgis:服务返回的消息
        /// </summary>
        public ServiceMessage(Exception ey, bool success)
        {
            this.Success = success;
            this.Data = default(T);
            this.ErrorInfo = ey?.Message;
        }

    }
}
