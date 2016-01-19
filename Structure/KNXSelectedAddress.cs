using System;

namespace Structure
{
    [Serializable]
    public class KNXSelectedAddress
    {
        public string Id { get; set; }

        public string Name { get; set; }

        // ��������
        public int Type { get; set; }

        //public string Type { get; set; }

        //public string Size { get; set; }

        // Ĭ��ֵ
        public string DefaultValue { get; set; }
    }
}