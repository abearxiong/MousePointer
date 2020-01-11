using CursorManageCommand;
using System;
using System.IO;
using System.Runtime.InteropServices;
namespace Cursor
{
    class Program
    {
        private static CursorManage cursorManage = new CursorManage();
        static void Main(string[] args)
        {
            // 1. 没有参数，那么不执行
            //Console.WriteLine("开始执行,参数个数"+args.Length);
            //Console.WriteLine(string.Join(" ",args));
            if (args.Length <= 0)
            {
                return;
            }
            if (args[0].Equals("set"))
            {
                var pt = args[1];
                if (Directory.Exists(pt))
                {
                    //Console.WriteLine(Path.GetFullPath(pt));
                    cursorManage.SetPath(Path.GetFullPath(pt) + "\\");
                    cursorManage.SetCursor();
                }
                else
                {
                    //Console.WriteLine("文件不存在");
                    MessageBox(IntPtr.Zero, "文件不存在", "提示", 0);
                }
            }
            if (args[0].Equals("remove"))
            {
                cursorManage.RecoverCursor();
            }
        }
        [DllImport("User32.dll")]
        public static extern int MessageBox(IntPtr hWnd, string lpText, string lpCaption, int uType);
    }
}
