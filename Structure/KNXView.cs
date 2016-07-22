
using System;
using System.ComponentModel;
using System.Drawing;

namespace Structure
{

    /**
     * KNX ��׼�������� DPT �ĳ��ȹ�ϵ
     * 
     * 1-Bit - (DPT 1.*) Boolean  0 - 1  Value display, Blinds, Switch, Slider switch, Snapper switch, Button, Media button, Scene button  
     * 4-Bit - (DPT 3.*) Controlled/Dimming  Up 0 - 7, Down 0 - 7  Snapper, Snapper switch, Button, Media button  
     * 8-Bit - (DPT 5.*) Unsigned Value  0 - 255  Value display, Slider, Slider switch, RGB color light, Button, Media button, Scene button  
     * 8-Bit - (DPT 6.*) Signed Value  -128 - 127  Value display, Slider, Slider switch, Button, Media button, Scene button  
     * 16-Bit - (DPT 7.*) Unsigned Value  0 - 65535  Value display, Slider, Slider switch, Button, Media button, Scene button  
     * 16-Bit - (DPT 8.*) Signed Value  -32768 - 32767  Value display, Slider, Slider switch, Button, Media button, Scene button  
     * 16-Bit - (DPT 9.*) Float Value   Value display, Slider, Slider switch, Button, Media button, Scene button  
     * 32-Bit - (DPT 12.*) Unsigned Value  0 - 4294967295  Value display, Button, Media button  
     * 32-Bit - (DPT 13.*) Signed Value  -2147483648 - 2147483647  Value display, Button, Media button  
     * 32-Bit - (DPT 14.*) Float Value   Value display, Button, Media button  
     * 14-Byte - (DPT 16.*) String Value   Value display, Button, Media button 
     */

    /*
     *  �ײ����ݳ��ȶ����ö��֮��Ĺ�ϵ
     *  
     *  { 1, 2, 3, 4, 5, 6, 7, 8, 16, 24, 32, 48, 64, 80, 112 }
     *  
     *  ��Ӧ��ϵ��
     *  Bit1 --> 1
     *  Bit2 --> 2
     *  Bit3 --> 3
     *  Bit4 --> 4
     *  Bit5 --> 5
     *  Bit6 --> 6
     *  Bit7 --> 7
     *  Bit8 --> 8
     *  Bit16 --> 16
     *  Bit24 --> 24
     *  Bit32 --> 32
     *  Bit48 --> 48
     *  Bit64 --> 64
     *  Bit80 --> 80
     *  Byte14 --> 112
     */
    public enum KNXDataType
    {
        Bit1,
        Bit2,
        Bit3,
        Bit4,
        Bit5, 
        Bit6,
        Bit7,
        Bit8,
        Bit16,
        Bit24,
        Bit32,
        Bit48, 
        Bit64,
        Bit80, 
        Bit112,
        None
    }

    /*
     *  KNX �п��ص����ȼ���ö�ٵĹ�ϵ��
     *  System --> 0
     *  Normal --> 1
     *  Urgent --> 2
     *  Low --> 3
     * 
     */
    public enum KNXPriority
    {
        System = 0, Normal = 1, Urgent = 2, Low = 3
    }

    public enum ControlType
    {
        Blinds, Button,
    }

    //��������Ҫ��ʾ�ķ���
    public enum SliderSymbol
    {
        None, DownUp, DardBright, SubtractAdd, Volume
    }

    /// <summary>
    /// ��ý�忪�صİ�ť����
    /// </summary>
    public enum MediaButtonType
    {
        Back = 0,
        Backward = 1,
        Menu = 2,
        Stop = 3,
        BackwardSkip = 4,
        Mute = 5,
        Up = 6,
        Okey = 7,
        VolumeDown = 8,
        Down = 9,
        Pause = 10,
        VolumeUp = 11,
        Forward = 12,
        Play = 13,
        ForwardSkip = 14,
        Power = 15,
        Left = 16,
        Right = 17
    }

    public enum Language
    {
        Chinese,
        English,
        French,
        German,
        Polish,
        Russian,
        Spanish,
        Japanese
    }

    public enum EMeasurementUnit
    {
        [Description("")]
        None,

        [Description("��")]
        Centigrade,

        [Description("�H")]
        Fahrenheit,

        [Description("A")]
        Ampere,

        [Description("mA")]
        Milliampere,

        [Description("KW")]
        Kilowatt
    }

    /// <summary>
    /// �ؼ���ƽ����ʽ
    /// </summary>
    public enum EFlatStyle
    {
        /// <summary>
        /// ��ƽ��
        /// </summary>
        Flat,

        /// <summary>
        /// ���廯
        /// </summary>
        Stereo,
    }

    public enum EBool
    {
        No,

        Yes
    }

    /// <summary>
    /// ����Ԫ�صĻ����࣬�ṩͳһ�Ļ�������
    /// </summary>    
    public class KNXView
    {
        /// <summary>
        /// ����Ԫ�ص�ID������Ӧ��Ψһ
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// ����Ԫ����Ҫ��ʾ��ǰ�˵�����
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// �ؼ�����ʼλ��x
        /// </summary>
        public int Left { get; set; }

        /// <summary>
        /// �ؼ�����ʼλ��y
        /// </summary>
        public int Top { get; set; }

        /// <summary>
        /// �ؼ��Ŀ��
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// �ؼ��Ŀ��
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// �Ƿ���ʾ�߿�
        /// </summary>
        public int DisplayBorder { get; set; }

        /// <summary>
        /// �߿���ɫ
        /// </summary>
        public string BorderColor { get; set; }

        /// <summary>
        /// �ؼ��Ĳ�͸����
        /// </summary>
        public double Alpha { get; set; }

        /// <summary>
        /// �ؼ���Բ�ǰ뾶
        /// </summary>
        public int Radius { get; set; }

        /// <summary>
        /// �ؼ������
        /// </summary>
        public int FlatStyle { get; set; }

        /// <summary>
        /// �ؼ��ı���ɫ
        /// </summary>
        public string BackgroundColor { get; set; }

        /// <summary>
        /// �ؼ��ı���ͼƬ
        /// </summary>
        public string BackgroundImage { get; set; }

        /// <summary>
        /// �ؼ���������ɫ
        /// </summary>
        public string FontColor { get; set; }

        /// <summary>
        /// �����С
        /// </summary>
        public int FontSize { get; set; }
    }
}
