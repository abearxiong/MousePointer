using CursorManageCommand;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CursorSetAutoRun
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private string path = ".\\";
        private List<CursorInfo> list;
        public MainWindow()
        {
            InitializeComponent();
            FilePath.Focus();
            InitList();
            ListDirectory();
        }
        public void ListDirectory()
        {
            listView.Items.Clear();
            string[] file = Directory.GetDirectories(".\\");
            foreach(var i in file)
            {
                listView.Items.Add(i);
            }
        }
        class CursorInfo
        {
            public string filePath;
            public string fileName;
            public bool ishave;
            public CursorInfo(string path, string fileName)
            {
                if (File.Exists(path + fileName + ".ani"))
                {
                    this.filePath = path + fileName + ".ani";
                    this.fileName = fileName + ".ani";
                    this.ishave = true;
                }
                else if (File.Exists(path + fileName + ".cur"))
                {
                    this.filePath = path + fileName + ".cur";
                    this.fileName = fileName + ".cur";
                    this.ishave = true;
                }
                else
                {
                    this.fileName = fileName+".ani";
                    this.filePath = "";
                    this.ishave = false;
                }
            }
        }
        public void InitList()
        {
            list = new List<CursorInfo>();
            list.Add(new CursorInfo(this.path, "Arrow"));
            list.Add(new CursorInfo(this.path, "Help"));
            list.Add(new CursorInfo(this.path, "Appstarting"));
            list.Add(new CursorInfo(this.path, "Wait"));
            list.Add(new CursorInfo(this.path, "Crosshair"));
            list.Add(new CursorInfo(this.path, "IBeam"));
            list.Add(new CursorInfo(this.path, "NWPen"));
            list.Add(new CursorInfo(this.path, "NO"));
            list.Add(new CursorInfo(this.path, "SizeNS"));
            list.Add(new CursorInfo(this.path, "SizeWE"));
            list.Add(new CursorInfo(this.path, "SizeNWSE"));
            list.Add(new CursorInfo(this.path, "SizeNESW"));
            list.Add(new CursorInfo(this.path, "SizeAll"));
            list.Add(new CursorInfo(this.path, "UpArrow"));
            list.Add(new CursorInfo(this.path, "Hand"));
            list.Add(new CursorInfo(this.path, "Pin"));
            list.Add(new CursorInfo(this.path, "Person"));
        }
        public void SetContent()
        {
            InitList();
            listView.Items.Clear();
            foreach (CursorInfo ci in list)
            {
                ListViewItem listViewItem = new ListViewItem
                {
                    Content = "拥有文件：" + ci.ishave + "\t" + ci.fileName + "\t" + ci.filePath
                };
                listView.Items.Add(listViewItem);
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (FilePath.Text != "")
            {
                path = FilePath.Text;
                if (!path.EndsWith(@"\"))
                {
                    path = path + @"\";
                }
            }
            if (Directory.Exists(path))
            {
                SetContent();
              }
                else
            {
                MessageBox.Show("目录不存在");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string head1= "[Version] \nsignature = \"$CHICAGO$\"";
            string head2 = "[DefaultInstall]\nCopyFiles = Scheme.Cur\nAddReg = Scheme.Reg,Wreg";
            string head3 = "[DestinationDirs]\nScheme.Cur = 10,\"%CUR_DIR%\"";
            string head4 = "[Scheme.Reg]\nHKCU,\"Control Panel\\Cursors\\Schemes\",\"%SCHEME_NAME%\",,\"%10%\\%CUR_DIR%\\%pointer%,%10%\\%CUR_DIR%\\%help%,%10%\\%CUR_DIR%\\%work%,%10%\\%CUR_DIR%\\%busy%,%10%\\%CUR_DIR%\\%Cross%,%10%\\%CUR_DIR%\\%Text%,%10%\\%CUR_DIR%\\%Hand%,%10%\\%CUR_DIR%\\%Unavailiable%,%10%\\%CUR_DIR%\\%Vert%,%10%\\%CUR_DIR%\\%Horz%,%10%\\%CUR_DIR%\\%Dgn1%,%10%\\%CUR_DIR%\\%Dgn2%,%10%\\%CUR_DIR%\\%move%,%10%\\%CUR_DIR%\\%alternate%,%10%\\%CUR_DIR%\\%link%\"";
            string headWreg = "" +
"[Wreg]" + "\n" +
"HKCU,\"Control Panel\\Cursors\",,0x00020000,\"%SCHEME_NAME%\"" + "\n" +
"HKCU,\"Control Panel\\Cursors\",AppStarting,0x00020000,\"%10%\\%CUR_DIR%\\%work%\"                                                     " + "\n" +
"HKCU,\"Control Panel\\Cursors\",Arrow,0x00020000,\"%10%\\%CUR_DIR%\\%pointer%\"                                                        " + "\n" +
"HKCU,\"Control Panel\\Cursors\",Crosshair,0x00020000,\"%10%\\%CUR_DIR%\\%Cross%\"                                                      " + "\n" +
"HKCU,\"Control Panel\\Cursors\",Hand,0x00020000,\"%10%\\%CUR_DIR%\\%link%\"                                                            " + "\n" +
"HKCU,\"Control Panel\\Cursors\",Help,0x00020000,\"%10%\\%CUR_DIR%\\%Help%\"                                                            " + "\n" +
"HKCU,\"Control Panel\\Cursors\",IBeam,0x00020000,\"%10%\\%CUR_DIR%\\%Text%\"                                                           " + "\n" +
"HKCU,\"Control Panel\\Cursors\",No,0x00020000,\"%10%\\%CUR_DIR%\\%Unavailiable%\"                                                      " + "\n" +
"HKCU,\"Control Panel\\Cursors\",NWPen,0x00020000,\"%10%\\%CUR_DIR%\\%Hand%\"                                                           " + "\n" +
"HKCU,\"Control Panel\\Cursors\",SizeAll,0x00020000,\"%10%\\%CUR_DIR%\\%move%\"                                                         " + "\n" +
"HKCU,\"Control Panel\\Cursors\",SizeNESW,0x00020000,\"%10%\\%CUR_DIR%\\%Dgn2%\"                                                        " + "\n" +
"HKCU,\"Control Panel\\Cursors\",SizeNS,0x00020000,\"%10%\\%CUR_DIR%\\%Vert%\"                                                          " + "\n" +
"HKCU,\"Control Panel\\Cursors\",SizeNWSE,0x00020000,\"%10%\\%CUR_DIR%\\%Dgn1%\"                                                        " + "\n" +
"HKCU,\"Control Panel\\Cursors\",SizeWE,0x00020000,\"%10%\\%CUR_DIR%\\%Horz%\"                                                          " + "\n" +
"HKCU,\"Control Panel\\Cursors\",UpArrow,0x00020000,\"%10%\\%CUR_DIR%\\%alternate%\"                                                    " + "\n" +
"HKCU,\"Control Panel\\Cursors\",Wait,0x00020000,\"%10%\\%CUR_DIR%\\%busy%\"                                                            " + "\n" +
"HKCU,\"Control Panel\\Cursors\",Pin,0x00020000,\"%10%\\%CUR_DIR%\\%pin%\"                                                              " + "\n" +
"HKCU,\"Control Panel\\Cursors\",Person,0x00020000,\"%10%\\%CUR_DIR%\\%person%\"                                                        " + "\n" +
"HKLM,\"SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Runonce\\Setup\\\",\"\",,\"rundll32.exe shell32.dll,Control_RunDLL main.cpl @0,1\"";

            string scheme = "[Scheme.Cur]\n";
            foreach (CursorInfo ci in list)
            {
                if (ci.ishave)
                {
                    scheme += ci.fileName + "\n";
                }
                else
                {
                    MessageBox.Show(ci.fileName + "不存在");
                    return;
                }
            }
            string setFileNameTemp = setFileName.Text == "" ? "无指针名字":setFileName.Text;
            string setting = "[Strings]\n"+
"CUR_DIR         	= \"Cursors\\" + setFileNameTemp + "\"\n" +
"SCHEME_NAME     	= \"" + setFileNameTemp + "\"\n" +
"pointer		= \"" + list[0].fileName + "\"\n" +
"help		= \"" + list[1].fileName + "\"\n" +
"work		= \"" + list[2].fileName + "\"\n" +
"busy		= \"" + list[3].fileName + "\"\n" +
"cross		= \"" + list[4].fileName + "\"\n" +
"text		= \"" + list[5].fileName + "\"\n" +
"hand		= \"" + list[6].fileName + "\"\n" +
"unavailiable	= \"" + list[7].fileName + "\"\n" +
"vert		= \"" + list[8].fileName + "\"\n" +
"horz		= \"" + list[9].fileName + "\"\n" +
"dgn1		= \"" + list[10].fileName + "\"\n" +
"dgn2		= \"" + list[11].fileName + "\"\n" +
"move		= \"" + list[12].fileName + "\"\n" +
"alternate		= \"" + list[13].fileName + "\"\n" +
"link		= \"" + list[14].fileName + "\"\n" +
"pin			= \"" + list[15].fileName + "\"\n" +
"person		= \"" + list[16].fileName + "\"\n"
                ;
            string writeFile = head1 + "\n" + head2 + "\n" + head3 + "\n" + head4 + "\n" + headWreg + "\n" + scheme + "\n" + setting;
            File.WriteAllText(path+"\\AutoSetup.inf", writeFile,Encoding.Default);
            MessageBox.Show("写入 "+path+"\\AutoSetup.inf完成");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string introduce = @"介绍：
1.本软件是为了我自己之后找鼠标的光标库，为了统一光标的安装方式写的。鼠标指针通过右键AutoSetup.inf安装，批量写AutoSetup.inf的一个初始例子。
2.规定了每一个指针光标的命名格式，之后有机会自己去找好看的光标文件。设定光标成库。
使用1.Path是文件的路径，相对路径是从程序的起始位置（只有一层），或自己写入绝对路径。 点击获取进入指针拥有的光标文件夹，列出规定的光标是否存在。
Name是设置需要的鼠标光标的名字。设置后，生成这个名字的AutoSetup.inf，右键安装后，可以在系统的鼠标属性，指针中看到这个名字，可以选择光标。

附加功能：进入了光标的文件点击（获取后）修改光标，鼠标变成那个目录的指针内容（缓存），恢复广播就是恢复成原本的。电脑重启后会到系统本身的光标显示。
";
            MessageBox.Show(introduce);
        }

        private void listView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ListView lv = (ListView)sender;
            //MessageBox.Show(listView.Items[0].ToString());
            Clipboard.SetText(lv.SelectedItem.ToString());
            string path = lv.SelectedItem.ToString();
            if (!Directory.Exists(path))
            {
                MessageBox.Show("不是文件夹");
                return;
            }

            if (!path.EndsWith(@"\"))
            {
                path = path + @"\";
            }
            this.path = path;
            SetContent();
        }
        private void FilePath_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (FilePath.Text == "")
            {
                ListDirectory();
            }
        }
        private CursorManage cm = new CursorManage();
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            
            cm.SetPath(this.path);
            cm.SetCursor();
            MessageBox.Show(cm.GetPath());
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            cm.RecoverCursor();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            this.path = ".\\";
            FilePath.Text = " ";
            FilePath.Text = "";
        }
    }
}
