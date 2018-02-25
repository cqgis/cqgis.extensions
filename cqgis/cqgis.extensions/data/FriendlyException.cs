using System;

namespace cqgis.extensions.data
{
    /// <summary>
    /// cqgis:正常逻辑中的异常
    /// </summary>
    public class FriendlyException : Exception
    {
        /// <summary>
        /// cqgis:正常逻辑中的异常
        /// </summary>
        public FriendlyException(string content) : base(content) { }
    }
}