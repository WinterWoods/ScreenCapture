using System;
using System.Collections.Generic;
using System.Text;

using System.Runtime.InteropServices;

namespace _SCREEN_CAPTURE_TOOL
{
    public class Win32
    {
        [DllImport("user32.dll")]//注册全局热键
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

        [DllImport("user32.dll")]//卸载全局热键
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        [DllImport("user32.dll")]
        public static extern IntPtr GetDesktopWindow();

        [DllImport("user32.dll")]
        public static extern bool InvalidateRect(IntPtr hWnd, ref LPRECT lpRect, bool bErase);

        public struct LPRECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }
        [DllImport("user32.dll", EntryPoint = "GetDCEx", CharSet = CharSet.Auto, ExactSpelling = true)]
        private static extern IntPtr GetDCEx(IntPtr hWnd, IntPtr hrgnClip, int flags);
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool RedrawWindow(IntPtr hwnd, ref LPRECT rcUpdate, IntPtr hrgnUpdate, int flags);

        public const int RDW_INVALIDATE = 0x1;
        public const int RDW_INTERNALPAINT = 0x2;
        public const int RDW_NOERASE = 0x20;
    }
}
