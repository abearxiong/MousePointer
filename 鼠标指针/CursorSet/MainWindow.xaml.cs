using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CursorManageCommand;
using CursorSet;
using MessageBox = System.Windows.Forms.MessageBox;

namespace CursorSet
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        //实例化notifyIOC控件最小化托盘
        private NotifyIcon notifyIcon = null;
        // 选择的光标
        private string ChooseCursor = "";
        // 设置光标的类
        private CursorManage cm = new CursorManage();
        // 设置最小化状态
        private bool minStatue = false;
        public MainWindow()
        {
            InitializeComponent();
            InitialTray(); // 托盘初始化
            SetPostion(); // 设置位置
            ReadConfig(); //读取配置
            ListDirectory(); //列出文件
        }
        public void SetPostion()
        {
            var wd = Screen.PrimaryScreen.Bounds.Width;
            var ht = Screen.PrimaryScreen.Bounds.Height;
            this.Left = wd - this.Width;
            this.Top = ht - this.Height;
        }
        public void ReadConfig()
        {
            Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (!cfa.HasFile)
            {
                cfa.AppSettings.Settings.Add("autoRun", "no");
                cfa.AppSettings.Settings.Add("chooseCursor", "");
                cfa.AppSettings.Settings.Add("isMin", "isMin");
                cfa.Save();
                return;
            }
            //cfa.AppSettings.Settings.Add("autoRun", false.ToString());
            //cfa.Save();
            var isChecked = GetConfig("autoRun");
            var isMin = GetConfig("isMin");
            myAutoRun.IsChecked = isChecked == "isChecked" ? true : false;
            minStatue = isMin == "isMin" ? true : false;
            ChooseCursor = ConfigurationManager.AppSettings["chooseCursor"];
            if (!string.IsNullOrEmpty(ChooseCursor))
            {
                var path = ".\\" + ChooseCursor + "\\";
                cm.SetPath(path);
                cm.SetCursor();
            }
            if (minStatue)
            {
                this.Close();   
            }
        }
        public void SetConfig(string key, string value)
        {
            Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            GetConfig(key);
            cfa.AppSettings.Settings[key].Value = value + "";
            cfa.Save();
        }
        public string GetConfig(string key)
        {
            var value = ConfigurationManager.AppSettings[key];
            if (value == null)
            {
                Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                cfa.AppSettings.Settings.Add(key, "");
                cfa.Save();
                return "";
            }
            return value;
        }
        // 选择指针设置
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            SetConfig("chooseCursor", ChooseCursor);
            var path = ".\\" + ChooseCursor + "\\";
            cm.SetPath(path);
            cm.SetCursor();

        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            cm.RecoverCursor();
            SetConfig("chooseCursor", "");
            ChooseCursor = "";
        }
        public void ListDirectory()
        {
            comboBox.Items.Clear();
            string[] file = Directory.GetDirectories(".\\");
            foreach (var i in file)
            {
                var getName = i.Substring(2);
                comboBox.Items.Add(getName);
                if (ChooseCursor == getName)
                {
                    comboBox.SelectedItem = getName;
                }
            }

        }
        // 最小化系统托盘
        private void InitialTray()
        {
            //隐藏主窗体
            //this.Visibility = Visibility.Hidden;
            //设置托盘的各个属性
            notifyIcon = new NotifyIcon
            {
                BalloonTipText = "鼠标指针美化.",//托盘气泡显示内容
                Text = "指针鼠标显示",
                Visible = true,//托盘按钮是否可见
                               //重要提示：此处的图标图片在resouces文件夹。可是打包后安装发现无法获取路径，导致程序死机。建议复制一份resouces文件到UI层的bin目录下，确保万无一失。
                Icon = new System.Drawing.Icon("./CursorSet.ico")//托盘中显示的图标
            };
            notifyIcon.ShowBalloonTip(1000);//托盘气泡显示时间
            //双击事件
            //_notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(notifyIcon_MouseClick);
            //鼠标点击事件
            notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(NotifyIcon_MouseClick);
            //右键菜单--退出菜单项
            System.Windows.Forms.MenuItem exit = new System.Windows.Forms.MenuItem("关闭");
            exit.Click += new EventHandler(Exit_Click);
            //关联托盘控件
            System.Windows.Forms.MenuItem[] childen = new System.Windows.Forms.MenuItem[] { exit };
            notifyIcon.ContextMenu = new System.Windows.Forms.ContextMenu(childen);
            //窗体状态改变时触发
            this.StateChanged += MainWindow_StateChanged;
        }
        // 托盘图标鼠标单击事件
        private void NotifyIcon_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //鼠标左键，实现窗体最小化隐藏或显示窗体
            if (e.Button == MouseButtons.Left)
            {
                if (this.Visibility == Visibility.Visible)
                {
                    this.Visibility = Visibility.Hidden;
                    //解决最小化到任务栏可以强行关闭程序的问题。
                    this.ShowInTaskbar = false;//使Form不在任务栏上显示
                }
                else
                {
                    this.Visibility = Visibility.Visible;
                    //解决最小化到任务栏可以强行关闭程序的问题。
                    this.ShowInTaskbar = false;//使Form不在任务栏上显示
                    minStatue = true;
                    SetConfig("isMin", "");
                    this.Activate();
                }
            }
            if (e.Button == MouseButtons.Right)
            {
                //object sender = new object();
                // EventArgs e = new EventArgs();
                Exit_Click(sender, e);//触发单击退出事件
            }
        }

        // 窗体状态改变时候触发
        private void SysTray_StateChanged(object sender, EventArgs e)
        {
            if (this.WindowState == WindowState.Minimized)
            {
                this.Visibility = Visibility.Hidden;
            }
        }

        // 退出选项
        private void Exit_Click(object sender, EventArgs e)
        {
            //if (System.Windows.MessageBox.Show("确定退出吗?",
            //                                   "退出",
            //                                    MessageBoxButton.YesNo,
            //                                    MessageBoxImage.Question,
            //                                    MessageBoxResult.Yes) == MessageBoxResult.Yes)
            //{
            //    //System.Windows.Application.Current.Shutdown();
            //    System.Environment.Exit(0);
            //}
            System.Environment.Exit(0);
        }

        // 窗口状态改变，最小化托盘
        private void MainWindow_StateChanged(object sender, EventArgs e)
        {
            if (this.WindowState == WindowState.Minimized)
            {
                this.Visibility = Visibility.Hidden;
            }
        }


        private void Window_Closed(object sender, EventArgs e)
        {
            //e.Cancel = true;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            minStatue = true;
            SetConfig("isMin", "isMin");
            this.Visibility = Visibility.Hidden;
            e.Cancel = true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            minStatue = true;
            SetConfig("isMin", "isMin");
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void MyAutoRun_Checked(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("显示");
            SetConfig("autoRun", "isChecked");
            SetAutoRun.SetMeStart(true);
        }

        private void MyAutoRun_Unchecked(object sender, RoutedEventArgs e)
        {
            SetConfig("autoRun", "no");
            SetAutoRun.SetMeStart(false);
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ChooseCursor = comboBox.SelectedItem.ToString();
            var absoultePath = System.Windows.Forms.Application.StartupPath;
            var imagePath = absoultePath+@".\" +ChooseCursor+ @"\cursor.png";
            if (File.Exists(imagePath))
            {
                BitmapImage bitmap = new BitmapImage(new Uri(imagePath, UriKind.RelativeOrAbsolute));
                cursorImage.Source = bitmap;
            }
            else
            {
                if(File.Exists(absoultePath+ @".\desc.png")){
                    cursorImage.Source = new BitmapImage(new Uri(absoultePath + @".\desc.png", UriKind.RelativeOrAbsolute));
                }
                else
                {
                    var errorFilePath = absoultePath + @".\log.text";
                    FileStream fs;
                    if (!File.Exists(errorFilePath))
                    {
                        fs = File.Create(errorFilePath);
                    }
                    else
                    {
                    fs = new FileStream(errorFilePath, FileMode.Open, FileAccess.ReadWrite);
                    }
                    StreamWriter sw = new StreamWriter(fs);
                    var err = "desc的图片和cursor的图片都没有";
                    sw.Write(err);
                    Console.WriteLine(err);
                    sw.Close();
                }
            }
        }
    }
}
