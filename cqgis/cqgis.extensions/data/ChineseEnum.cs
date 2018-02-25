using System;
using System.Collections.Generic;
using System.Text;

namespace cqgis.extensions.data
{
    ///<summary>
    /// cqgis:字段的中文名称特性
    ///</summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public sealed class ChineseAttribute : Attribute
    {
        ///<summary>
        /// cqgis:中文名称 
        ///</summary>
        public string ChineseName { get; private set; }
        /// <summary>
        /// cqgis:枚举值的中文名称
        /// </summary>
        /// <param name="chinese"></param>
        public ChineseAttribute(string chinese)
        {
            ChineseName = chinese; 
        }
    }
}
