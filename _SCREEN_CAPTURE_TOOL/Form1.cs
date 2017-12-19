using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using _SCREEN_CAPTURE;
using System.Runtime.InteropServices;
using System.IO;
using Microsoft.Win32;

namespace _SCREEN_CAPTURE_TOOL
{
    public partial class Form1 : Form
    {
        public Form1() {
            InitializeComponent();

            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;

            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;

            //手动绑定事件 本来里面就一两句 单独一个方法没必要
            this.FormClosing += (s, e) => { e.Cancel = true; this.Hide(); };
            this.notifyIcon1.DoubleClick += (s, e) => this.ShowWindow();
            this.showMainWindowToolStripMenuItem.Click += (s, e) => this.ShowWindow();
            this.exitToolStripMenuItem.Click += (s, e) => this.ExitApp();

            m_keyHook = new KeyHook();
            m_keyHook.KeyHookEvent += new KeyHook.KeyHookHanlder(m_keyHook_KeyHookEvent);
            m_dtLastDownPrt = DateTime.Now;
        }

        private const int HOTKEY_N_ID = 1000;
        private const int HOTKEY_C_ID = 1001;
        private const uint WM_HOTKEY = 0x312;
        private const uint MOD_ALT = 0x1;
        private const uint MOD_CONTROL = 0x2;
        private const uint MOD_SHIFT = 0x4;

        private FrmCapture m_frmCapture;
        //保存当前设置的临时变量
        private uint m_uCtrlKey_n;
        private uint m_uCtrlKey_c;
        private uint m_uAuxKey_n;
        private uint m_uAuxKey_c;
        private bool m_bAutoRun;
        private bool m_bCaptureCur;

        private KeyHook m_keyHook;
        private DateTime m_dtLastDownPrt;

        public NotifyIcon NotiFyIcon {
            get { return notifyIcon1; }
        }

        private void Form1_Load(object sender, EventArgs e) {
            m_keyHook.SetHook();
            if (!this.LoadSetting()) {  //加载用户设置 如果失败使用默认设置
                if (Win32.RegisterHotKey(this.Handle, HOTKEY_N_ID, MOD_SHIFT | MOD_ALT, (int)Keys.A)) {
                    chkBox_alt_n.Checked = chkBox_shift_n.Checked = true;
                    textBox1.Text = "A";
                }
                if (Win32.RegisterHotKey(this.Handle, HOTKEY_C_ID, MOD_CONTROL | MOD_ALT, (int)Keys.N)) {
                    chkBox_alt_c.Checked = chkBox_ctrl_c.Checked = true;
                    textBox2.Text = "N";
                }
                MessageBox.Show("Load setting fialed!");
                return;
            }
            this.Location = new Point(-500, -500);  //将窗体搞出屏幕外(否则一闪而过)
            this.BeginInvoke(new MethodInvoker(() => this.Visible = false));    //因为直接this.visible = false没用
            notifyIcon1.Visible = true;     //托盘来一个气泡提示
            notifyIcon1.ShowBalloonTip(30, "ScreenCapture", "ScreenCapture has started!", ToolTipIcon.Info);
        }
        //获取辅助按键
        private void textBox_KeyDown(object sender, KeyEventArgs e) {
            if ("None" != e.Modifiers.ToString()) { //禁止输入控制键(非alt ctrl shift...)
                MessageBox.Show("Can not input control keys!");
                return;
            }
            (sender as TextBox).Text = e.KeyCode.ToString();   //显示点下的按键
        }
        //设置
        private void button1_Click(object sender, EventArgs e) {
            if ((!chkBox_ctrl_n.Checked && !chkBox_alt_n.Checked && !chkBox_shift_n.Checked) ||
                (!chkBox_ctrl_c.Checked && !chkBox_alt_c.Checked && !chkBox_shift_c.Checked)) {
                MessageBox.Show("Maybe you should select a control key!");
                return;     //至少选择一个控制键(alt ctrl shift)
            }
            if (textBox1.Text == "" || textBox2.Text == "") {
                MessageBox.Show("Maybe you should select a auxiliary key!");
                return;     //必须确定一个辅助键(非alt ctrl shift)
            }
            if (checkBox_AutoRun.Checked) {
                if (DialogResult.No == MessageBox.Show(
                    "\"AutoRun\" will start after the computer start up!\r\n" +
                    "Please keep the path exsit.\r\nContinue?", "question", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) {
                    return; //如果选择了开机自起 那么提示保持当前路径的存在
                }
            }
            //如果满足要求开始设置
            m_uCtrlKey_n = 0
                | (chkBox_ctrl_n.Checked ? MOD_CONTROL : 0)
                | (chkBox_alt_n.Checked ? MOD_ALT : 0)
                | (chkBox_shift_n.Checked ? MOD_SHIFT : 0);
            m_uAuxKey_n = Convert.ToUInt32((Keys)Enum.Parse(typeof(Keys), textBox1.Text));
            m_uCtrlKey_c = 0
                | (chkBox_ctrl_c.Checked ? MOD_CONTROL : 0)
                | (chkBox_alt_c.Checked ? MOD_ALT : 0)
                | (chkBox_shift_c.Checked ? MOD_SHIFT : 0);
            m_uAuxKey_c = Convert.ToUInt32((Keys)Enum.Parse(typeof(Keys), textBox2.Text));

            m_bAutoRun = checkBox_AutoRun.Checked;
            m_bCaptureCur = checkBox_CaptureCursor.Checked;

            if (!Win32.UnregisterHotKey(this.Handle, HOTKEY_N_ID))                  //卸载原来的热键
                MessageBox.Show("[Normal]The orginal hotkey uninstallation failed!");
            if (!Win32.RegisterHotKey(this.Handle, HOTKEY_N_ID, m_uCtrlKey_n, m_uAuxKey_n))   //登记新的热键
                MessageBox.Show("[Normal]The new hotkey failed to install!");

            if (!Win32.UnregisterHotKey(this.Handle, HOTKEY_C_ID))                  //卸载原来的热键
                MessageBox.Show("[FromClipBoard]The orginal hotkey uninstallation failed!");
            if (!Win32.RegisterHotKey(this.Handle, HOTKEY_C_ID, m_uCtrlKey_c, m_uAuxKey_c))   //登记新的热键
                MessageBox.Show("[FromClipBoard]The new hotkey failed to install!");
            //将设置存入文件
            FileStream fs = new FileStream("CaptureSetting.cfg", FileMode.Create);
            fs.Write(BitConverter.GetBytes(m_uCtrlKey_n), 0, 4);      //保存控制键
            fs.Write(BitConverter.GetBytes(m_uAuxKey_n), 0, 4);       //保存辅助键
            fs.Write(BitConverter.GetBytes(m_uCtrlKey_c), 0, 4);      //保存控制键
            fs.Write(BitConverter.GetBytes(m_uAuxKey_c), 0, 4);       //保存辅助键
            fs.WriteByte((byte)(m_bAutoRun ? 1 : 0));               //保存是否自起
            fs.WriteByte((byte)(m_bCaptureCur ? 1 : 0));            //保存是否捕获鼠标
            fs.Close();
            //根据情况是否写入注册表
            RegistryKey regKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run\", true);
            if (checkBox_AutoRun.Checked) {
                if (regKey == null)
                    regKey = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run\");
                regKey.SetValue("ScreenCapture", Application.ExecutablePath);
            } else {
                if (regKey != null) {
                    if (regKey.GetValue("ScreenCapture") != null)
                        regKey.DeleteValue("ScreenCapture");
                }
            }
            regKey.Close();
            MessageBox.Show("Setting Finish!");
        }
        //重写消息循环
        protected override void WndProc(ref Message m) {
            if (m.Msg == WM_HOTKEY) {
                if (m.WParam == (IntPtr)HOTKEY_N_ID)
                    this.StartCapture(false);
                else if (m.WParam == (IntPtr)HOTKEY_C_ID)
                    this.StartCapture(true);
            }
            base.WndProc(ref m);
        }
        //如果要捕获鼠标 对PrtScr键进行拦截
        private void m_keyHook_KeyHookEvent(object sender, KeyHookEventArgs e) {
            if (e.KeyCode == (int)Keys.PrintScreen && checkBox_CaptureCursor.Checked) {
                if (DateTime.Now.Subtract(m_dtLastDownPrt).TotalMilliseconds > 500)
                    FrmCapture.DrawCurToScreen();       //如果按下不松开会一直触发
                m_dtLastDownPrt = DateTime.Now;
                //下面是尝试了些在桌面绘制了鼠标之后然后将画上去的鼠标刷掉 结果貌似失败了  算了
                //Console.WriteLine(rect.ToString());
                //Win32.LPRECT lpRect = new Win32.LPRECT() {
                //    Left = rect.Left, Top = rect.Top,
                //    Right = rect.Right, Bottom = rect.Bottom
                //};
                //IntPtr desk = Win32.GetDesktopWindow();
                //IntPtr deskDC = Win32.GetDCEx(desk, IntPtr.Zero, 0x403);
                //Graphics g = Graphics.FromHdc(deskDC);
                //g.FillRectangle(new SolidBrush(Color.FromArgb(128, Color.Red)), new Rectangle(100, 100, 400, 400)); 
                //Console.WriteLine(Win32.RedrawWindow(IntPtr.Zero, ref lpRect, IntPtr.Zero, 0x85));
                //Console.WriteLine((Win32.RDW_INTERNALPAINT | Win32.RDW_INVALIDATE | Win32.RDW_NOERASE).ToString("X"));
                //Console.WriteLine(Win32.InvalidateRect(Win32.GetDesktopWindow(), ref lpRect, false));
                //Console.WriteLine(lpRect.Left + " " + lpRect.Top + " " + lpRect.Right + " " + lpRect.Bottom);
            }
        }
        //启动截图
        private void StartCapture(bool bFromClip) {
            if (m_frmCapture == null || m_frmCapture.IsDisposed)
                m_frmCapture = new FrmCapture();
            m_frmCapture.IsCaptureCursor = checkBox_CaptureCursor.Checked;
            m_frmCapture.IsFromClipBoard = bFromClip;
            m_frmCapture.Show();
        }
        //从文件加载用户的设置
        private bool LoadSetting() {
            //【注意】用绝对路径 如果开机启动的话还没有完全进入系统程序就启动 使用相对路径可能无法找到文件
            if (!File.Exists(Application.StartupPath + "\\CaptureSetting.cfg"))      //从文件中获取设置
                return false;
            byte[] byTemp = File.ReadAllBytes(Application.StartupPath + "\\CaptureSetting.cfg");
            if (byTemp.Length != 18)
                return false;
            m_uCtrlKey_n = BitConverter.ToUInt32(byTemp, 0);
            m_uAuxKey_n = BitConverter.ToUInt32(byTemp, 4);
            m_uCtrlKey_c = BitConverter.ToUInt32(byTemp, 8);
            m_uAuxKey_c = BitConverter.ToUInt32(byTemp, 12);

            if (!Win32.RegisterHotKey(this.Handle, HOTKEY_N_ID, m_uCtrlKey_n, m_uAuxKey_n))
                return false;
            textBox1.Text = ((Keys)m_uAuxKey_n).ToString();
            chkBox_ctrl_n.Checked = (m_uCtrlKey_n & MOD_CONTROL) != 0;
            chkBox_alt_n.Checked = (m_uCtrlKey_n & MOD_ALT) != 0;
            chkBox_shift_n.Checked = (m_uCtrlKey_n & MOD_SHIFT) != 0;

            if (!Win32.RegisterHotKey(this.Handle, HOTKEY_C_ID, m_uCtrlKey_c, m_uAuxKey_c))
                return false;
            textBox2.Text = ((Keys)m_uAuxKey_c).ToString();
            chkBox_ctrl_c.Checked = (m_uCtrlKey_c & MOD_CONTROL) != 0;
            chkBox_alt_c.Checked = (m_uCtrlKey_c & MOD_ALT) != 0;
            chkBox_shift_c.Checked = (m_uCtrlKey_c & MOD_SHIFT) != 0;

            checkBox_AutoRun.Checked = m_bAutoRun = Convert.ToBoolean(byTemp[16]);
            checkBox_CaptureCursor.Checked = m_bCaptureCur = Convert.ToBoolean(byTemp[17]);
            return true;
        }
        //加载当前的设置显示到窗体
        private void ShowCurrentSetting() {
            textBox1.Text = ((Keys)m_uAuxKey_n).ToString();
            chkBox_ctrl_n.Checked = (m_uCtrlKey_n & MOD_CONTROL) != 0;
            chkBox_alt_n.Checked = (m_uCtrlKey_n & MOD_ALT) != 0;
            chkBox_shift_n.Checked = (m_uCtrlKey_n & MOD_SHIFT) != 0;

            textBox2.Text = ((Keys)m_uAuxKey_c).ToString();
            chkBox_ctrl_c.Checked = (m_uCtrlKey_c & MOD_CONTROL) != 0;
            chkBox_alt_c.Checked = (m_uCtrlKey_c & MOD_ALT) != 0;
            chkBox_shift_c.Checked = (m_uCtrlKey_c & MOD_SHIFT) != 0;

            checkBox_AutoRun.Checked = m_bAutoRun;
            checkBox_CaptureCursor.Checked = m_bCaptureCur;
        }
        //显示窗体
        private void ShowWindow() {
            this.Location = new Point(
                (Screen.PrimaryScreen.Bounds.Width - this.Width) / 2,
                (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2);
            this.ShowCurrentSetting();
            this.Visible = true;
            this.Activate();
        }
        //退出程序
        private void ExitApp() {
            notifyIcon1.Visible = false;
            Win32.UnregisterHotKey(this.Handle, HOTKEY_N_ID);
            Win32.UnregisterHotKey(this.Handle, HOTKEY_C_ID);
            m_keyHook.UnLoadHook();
            Environment.Exit(0);    //Application.Exit()会被 this.Closing拦截
        }
    }
}
