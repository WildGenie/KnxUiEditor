using System.Collections.Generic;

namespace Structure
{
    /// <summary>
    /// �����࣬�ؼ�Ԫ�ص�����
    /// </summary>
    public class KNXContainer : KNXControlBase
    {
        /// <summary>
        /// �ڷ��ڽ����ϵ��ӿؼ�
        /// </summary>
        public List<KNXControlBase> Controls { get; set; }
    }
}