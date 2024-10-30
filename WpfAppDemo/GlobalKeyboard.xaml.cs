using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfAppDemo
{
    /// <summary>
    /// GlobalKeyboard.xaml 的交互逻辑
    /// </summary>
    public partial class GlobalKeyboard : Window
    {
        private const int WM_HOTKEY = 0x0312;
        private const int HotKeyId = 9000;
        private IntPtr _windowHandle;
        public GlobalKeyboard()
        {
            InitializeComponent();
        }
        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            _windowHandle = new WindowInteropHelper(this).Handle;
            HwndSource hWndSource = HwndSource.FromHwnd(_windowHandle);
            if (hWndSource != null)
            {
                hWndSource.AddHook(WndProc);
            }
            RegisterHotKey();
        }
        protected override void OnClosed(EventArgs e)
        {
            UnregisterHotKey();
            base.OnClosed(e);
        }
        private void RegisterHotKey()
        {
            // 注册 Alt + F3
            NativeMethods.RegisterHotKey(_windowHandle, HotKeyId, 0x0001, (int)KeyInterop.VirtualKeyFromKey(Key.F3));
        }

        private void UnregisterHotKey()
        {
            NativeMethods.UnregisterHotKey(_windowHandle, HotKeyId);
        }

        private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            if (msg == WM_HOTKEY && wParam.ToInt32() == HotKeyId)
            {
                ShowMyWindow();
                handled = true;
            }
            return IntPtr.Zero;
        }

        private void ShowMyWindow()
        {
            //MyWindow myWindow = new MyWindow();
            //myWindow.Show();
        }
        internal static class NativeMethods
        {
            [DllImport("user32.dll")]
            public static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, int vk);

            [DllImport("user32.dll")]
            public static extern bool UnregisterHotKey(IntPtr hWnd, int id);
        }
    }
}
