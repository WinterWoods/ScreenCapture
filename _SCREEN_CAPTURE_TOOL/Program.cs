using System;
using System.Collections.Generic;
using System.Windows.Forms;

using System.Threading;

namespace _SCREEN_CAPTURE_TOOL
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            bool bCreateNew = false;
            using (Mutex mutex = new Mutex(true, "_SCREEN_CAPTURE_TOOL_", out bCreateNew)) {
                if (bCreateNew) {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Form1());
                } else {
                    new Form1().NotiFyIcon.ShowBalloonTip(30, "ScreenCapture", "The ScreenCapture has run an instance", ToolTipIcon.Warning);
                }
            }
        }
    }
}
