using System;
using System.Collections;
using System.IO;
using System.Runtime.InteropServices;
namespace CursorManageCommand
{
    class CursorManage
    {
        //导入API
        #region User32.dll functions
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr LoadCursorFromFile(string fileName);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool SetSystemCursor(IntPtr hcur, uint id);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool SystemParametersInfo(uint uiAction, uint uiParam, IntPtr pvParam, uint fWinlni);
        #endregion

        private const uint OCR_APPSTARTING = 32650; // Standard arrow and small hourglass 后台运行
        private const uint OCR_NORMAL = 32512; //Standard arrow 正常选择
        private const uint OCR_CROSS = 32515; //Crosshair 精确选择
        private const uint OCR_HAND = 32649; //Hand 连接选择
        private const uint OCR_HELP = 32651; //Arrow and question mark 帮助选择
        private const uint OCR_IBEAM = 32513; //I-beam 文本选择
        private const uint OCR_NO = 32648; //Slashed circle 不可用
        private const uint OCR_SIZEALL = 32646; //Four-pointed arrow pointing north, south, east, and west 移动
        private const uint OCR_SIZENESW = 32643; //Double-pointed arrow pointing northeast and southwest 沿对角线调正大小2
        private const uint OCR_SIZENS = 32645; //Double-pointed arrow pointing north and south 垂直调整大小
        private const uint OCR_SIZENWSE = 32642; //Double-pointed arrow pointing northwest and southeast 沿对角线调整大小1
        private const uint OCR_SIZEWE = 32644; //Double-pointed arrow pointing west and east 水平调整大小
        private const uint OCR_UP = 32516; //Vertical arrow 候选
        private const uint OCR_WAIT = 32514; //Hourglass 忙
        private const uint OCR_PIN = 0; // 地址选择
        private const uint OCR_PERSON = 0; //个人选择
        private const uint OCR_NWPEN = 0; //手写输入

        private const uint SPI_SETCURSORS = 87;
        private const uint SPIF_SENDWININICHANGE = 2;

        //private string path = @"E:\图片收集\升级桌面\鼠标指针库\repos\neovison\";
        //private string path = @"E:\图片收集\升级桌面\鼠标指针库\repos\hands\";
        private string path = ".\\";
        class CursorShow
        {
            public string filePath;
            public string fileName;
            public uint OCR;
            public CursorShow(string path,string fileName,uint OCR)
            {
                this.fileName = File.Exists(path  + fileName + ".ani") ? fileName + ".ani" : fileName + ".cur";
                this.filePath = path + this.fileName;
                this.OCR = OCR;
            }
        };
        public ArrayList list = new ArrayList();
        private string Arrow = "Arrow";
        private string Help = "Help";
        private string Wait = "Wait";
        private string Appstarting = "Appstarting";
        private string Crosshair = "Crosshair";
        private string IBeam = "IBeam";
        private string NWPen = "NWPen";
        private string NO = "NO";
        private string SizeNS = "SizeNS";
        private string SizeWE = "SizeWE";
        private string SizeNWSE = "SizeNWSE";
        private string SizeNESW = "SizeNESW";
        private string SizeAll = "SizeAll";
        private string UpArrow = "UpArrow";
        private string Hand = "Hand";
        private string Pin = "Pin";
        private string Person = "Person";
        private void InitCursor()
        {
            list.Clear();
            new CursorShow(path, Arrow, OCR_NORMAL);
            list.Add(new CursorShow(path , Arrow, OCR_NORMAL));
            list.Add(new CursorShow(path , Help, OCR_HELP));
            list.Add(new CursorShow(path , Wait, OCR_WAIT));
            list.Add(new CursorShow(path , Appstarting, OCR_APPSTARTING));
            list.Add(new CursorShow(path , Crosshair, OCR_CROSS));
            list.Add(new CursorShow(path , IBeam, OCR_IBEAM));
            list.Add(new CursorShow(path , NWPen, OCR_NWPEN));
            list.Add(new CursorShow(path , NO, OCR_NO));
            list.Add(new CursorShow(path , SizeNS, OCR_SIZENS));
            list.Add(new CursorShow(path , SizeWE, OCR_SIZEWE));
            list.Add(new CursorShow(path , SizeNWSE, OCR_SIZENWSE));
            list.Add(new CursorShow(path , SizeNESW, OCR_SIZENESW));
            list.Add(new CursorShow(path , SizeAll, OCR_SIZEALL));
            list.Add(new CursorShow(path , UpArrow, OCR_UP));
            list.Add(new CursorShow(path , Hand, OCR_HAND));
            list.Add(new CursorShow(path , Pin, OCR_PIN));
            list.Add(new CursorShow(path , Person, OCR_PERSON));
        }
        public void SetPath(string path)
        {
            this.path = path;
        }
        public string GetPath()
        {
            return this.path;
        }
        public void SetCursor()
        {
            InitCursor();
            foreach(CursorShow cs in list)
            {
                SetSystemCursor(LoadCursorFromFile(cs.filePath),cs.OCR);
            }
        }
        public void RecoverCursor()
        {
            SystemParametersInfo(SPI_SETCURSORS, 0, IntPtr.Zero, SPIF_SENDWININICHANGE);
        }
    }
}
