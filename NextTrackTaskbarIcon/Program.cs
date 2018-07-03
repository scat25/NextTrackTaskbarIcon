using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace NextTrackTaskbarIcon
{

    static class Program
    {
        static NotifyIcon icon;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            icon = new NotifyIcon();
            icon.Icon = Properties.Resources.next;
            icon.Visible = true;
            icon.Click += new System.EventHandler(Program.Next);
            Application.Run();
        }

        static void Next(object Sender, EventArgs e)
        {
            keybd_event(VK_MEDIA_NEXT_TRACK, 0, KEYEVENTF_EXTENDEDKEY, IntPtr.Zero);
            keybd_event(VK_MEDIA_NEXT_TRACK, 0, KEYEVENTF_KEYUP, IntPtr.Zero);
        }

        //https://stackoverflow.com/a/41534820/4787593
        [DllImport("user32.dll", SetLastError = true)]
        public static extern void keybd_event(byte virtualKey, byte scanCode, uint flags, IntPtr extraInfo);

        public const int VK_MEDIA_NEXT_TRACK = 0xB0;
        public const int VK_MEDIA_PLAY_PAUSE = 0xB3;
        public const int VK_MEDIA_PREV_TRACK = 0xB1;
        public const int KEYEVENTF_EXTENDEDKEY = 0x0001; //Key down flag
        public const int KEYEVENTF_KEYUP = 0x0002; //Key up flag
    }
}
