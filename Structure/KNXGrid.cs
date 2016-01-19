﻿

namespace Structure
{
    /// <summary>
    /// 表格，主要用于界面上元素的布局
    /// </summary>
    public class KNXGrid : KNXContainer
    {
        /// <summary>
        /// 当前格子从哪一行开始
        /// </summary>
        public int Row { get; set; }

        /// <summary>
        /// 当前的表格从哪一列开始
        /// </summary>
        public int Column { get; set; }

        /// <summary>
        /// 占几个行
        /// </summary>
        public int RowSpan { get; set; }

        /// <summary>
        /// 占几列
        /// </summary>
        public int ColumnSpan { get; set; }

        /// <summary>
        /// grid 边框样式
        /// </summary>
        public string BorderStyle { get; set; }

    }
}
