using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CursorSet
{
    class AutoRun
    {
        public void SetAutoRun()
        {
            #region 设置开机自启
            string strName = AppDomain.CurrentDomain.BaseDirectory + "AutoRunPro.exe";//获取要自动运行的应用程序名
            if (!System.IO.File.Exists(strName))//判断要自动运行的应用程序文件是否存在
                return;
            string strnewName = strName.Substring(strName.LastIndexOf("\\") + 1);//获取应用程序文件名，不包括路径
            RegistryKey registry = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);//检索指定的子项
            if (registry == null)//若指定的子项不存在
                registry = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run");//则创建指定的子项
            registry.SetValue(strnewName, strName);//设置该子项的新的“键值对”

            if (MessageBox.Show("设置完毕") == DialogResult.OK)
            {
                RefreshSystem();//刷新系统
            }
            #endregion
        }
        public void SetNoAutoRun()
        {
            #region 取消开机自启
            string strName = AppDomain.CurrentDomain.BaseDirectory + "AutoRunPro.exe";//获取要自动运行的应用程序名
            if (!System.IO.File.Exists(strName))//判断要取消的应用程序文件是否存在
                return;
            string strnewName = strName.Substring(strName.LastIndexOf("\\") + 1);///获取应用程序文件名，不包括路径
            RegistryKey registry = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);//读取指定的子项
            if (registry == null)//若指定的子项不存在
                registry = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run");//则创建指定的子项
            registry.DeleteValue(strnewName, false);//删除指定“键名称”的键/值对
            if (MessageBox.Show("设置完毕") == DialogResult.OK)
            {
                RefreshSystem();
            }
            #endregion
        }
        public void RefreshSystem()
        {
            Process[] myProcesses;
            myProcesses = Process.GetProcessesByName("explorer");
            foreach (Process myProcess in myProcesses)
            {

                myProcess.Kill();

            }
            System.Diagnostics.Process.Start("explorer.exe");
        }
    }
}
