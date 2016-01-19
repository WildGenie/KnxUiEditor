using System.Collections.Generic;

namespace Structure
{
    /// <summary>
    /// �ؼ�������
    /// </summary>
    public class KNXControlBase : KNXView
    {
        /// <summary>
        /// �ؼ�λ�ã�λ�ڸ��ؼ������е�λ��
        /// ��
        /// </summary>
        public int Column { get; set; }

        /// <summary>
        /// ��
        /// </summary>
        public int Row { get; set; }
        /// <summary>
        /// ��Խ������
        /// </summary>
        public int ColumnSpan { get; set; }
        /// <summary>
        /// ��Խ������
        /// </summary>
        public int RowSpan { get; set; }

        /// <summary>
        /// ����ɫ
        /// </summary>
        public string BackColor { get; set; }

        /// <summary>
        /// ǰ��ɫ
        /// </summary>
        public string ForeColor { get; set; }

        public bool HasTip { get; set; }

        public string Tip { get; set; }

        /// <summary>
        /// ����ַ
        /// </summary>
        public Dictionary<string, KNXSelectedAddress> ReadAddressId { get; set; }
        /// <summary>
        /// ETS��Ŀ�иÿؼ���ID
        /// </summary>
        public Dictionary<string, KNXSelectedAddress> WriteAddressIds { get; set; }

    }
}