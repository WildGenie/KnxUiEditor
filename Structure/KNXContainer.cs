using System.Collections.Generic;

namespace Structure
{
    /// <summary>
    /// �����࣬�ؼ�Ԫ�ص�����
    /// </summary>
    public class KNXContainer : KNXView
    {
        /// <summary>
        /// ��ǰ�ĸ��ӻ���Ϊ����
        /// </summary>
        public int RowCount { get; set; }

        /// <summary>
        /// ��ǰ�ĸ��ӻ���Ϊ����
        /// </summary>
        public int ColumnCount { get; set; }

        /// <summary>
        /// �ڷ��ڽ����ϵ��ӿؼ�
        /// </summary>
        public List<KNXControlBase> Controls { get; set; }
    }
}