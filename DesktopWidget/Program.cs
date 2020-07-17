using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopWidget
{
    static class Program
    {
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private const int WM_KEYUP = 0x0101;

        private const int WH_MOUSE_LL = 14;
        private const int WM_LBUTTONDOWN = 0x0201;
        private const int WM_LBUTTONUP = 0x0202;

        private static DesktopWidget dw;
        private static LowLevelKeyboardProc _keyProc = KeyboardHookCallback;
        private static LowLevelMouseProc _mouseProc = MouseHookCallback;

        private static IntPtr _keyHookID = IntPtr.Zero;
        private static IntPtr _mouseHookID = IntPtr.Zero;

        private static List<string> shortcutKeys = new List<string>();
        private static List<string> keysHeld = new List<string>();
        private static bool hasToHold = false;
        private static bool _runningEyeDrop = false;

        public static Point CursorPosition = Point.Empty;

        public static bool RunningEyeDropper
        {
            get
            {
                return _runningEyeDrop;
            }
            set
            {
                _runningEyeDrop = value;
                TriggerMouseHook();
            }
        }

        public static void TriggerMouseHook()
        {
            if (_runningEyeDrop)
                _mouseHookID = SetMouseHook(_mouseProc);
            else
            {
                UnhookWindowsHookEx(_mouseHookID);
                CursorPosition = Point.Empty;
            }
        }

        [STAThread]
        static void Main()
        {
            if (Properties.Settings.Default.AllowDisposal && Properties.Settings.Default.AllowShortcut)
            {
                MatchCollection _keys = Regex.Matches(Properties.Settings.Default.ShortcutKeys, @"(\w+)?(?=\+)?(\w+)");

                foreach (Match str in _keys)
                {
                    switch (str.ToString().ToLower())
                    {
                        case "hold":
                            hasToHold = true;
                            break;
                        case "ctrl":
                            shortcutKeys.Add("control");
                            break;
                        case "alt":
                            shortcutKeys.Add("menu");
                            break;
                        case "shift":
                            shortcutKeys.Add("shift");
                            break;
                        case "break":
                            shortcutKeys.Add("pause");
                            break;
                    }
                }

                _keyHookID = SetKeyHook(_keyProc);
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            dw = new DesktopWidget();

            Application.Run(dw);

            if (Properties.Settings.Default.AllowDisposal && Properties.Settings.Default.AllowShortcut)
                UnhookWindowsHookEx(_keyHookID);

            UnhookWindowsHookEx(_mouseHookID);
        }

        private static IntPtr SetKeyHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            {
                using (ProcessModule curModule = curProcess.MainModule)
                {
                    return SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
                }
            }
        }

        private static IntPtr SetMouseHook(LowLevelMouseProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            {
                using (ProcessModule curModule = curProcess.MainModule)
                {
                    return SetWindowsHookEx(WH_MOUSE_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
                }
            }
        }

        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);
        private delegate IntPtr LowLevelMouseProc(int nCode, IntPtr wParam, IntPtr lParam);

        private static IntPtr MouseHookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (RunningEyeDropper)
            {
                if (nCode >= 0)
                {
                    if (wParam == (IntPtr)WM_LBUTTONDOWN)
                    {
                        CursorPosition = Cursor.Position;
                    }
                }
            }

            return CallNextHookEx(_mouseHookID, nCode, wParam, lParam);
        }

        private static IntPtr KeyboardHookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
            {
                int vkCode = Marshal.ReadInt32(lParam);
                Keys vkKey = (Keys)vkCode;
                string vk = KeyFromString(vkKey.ToString().ToLower());

                if (!keysHeld.Contains(vk))
                    keysHeld.Add(vk);

                if (hasToHold)
                {
                    Timer timer = new Timer();

                    timer.Tick += new EventHandler(
                        delegate
                        {
                            if (IsShortcutComplete())
                            {
                                dw.DoTaskDisposal();
                                keysHeld.Clear();
                            }

                            timer.Dispose();
                        }
                    );

                    timer.Interval = 3000;
                    timer.Enabled = true;
                }
                else
                {
                    if (IsShortcutComplete())
                    {
                        dw.DoTaskDisposal();
                        keysHeld.Clear();
                    }
                }
            }
            else if (wParam == (IntPtr)WM_KEYUP)
                keysHeld.Clear();

            return CallNextHookEx(_keyHookID, nCode, wParam, lParam);
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelMouseProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        private static string KeyFromString(string vk)
        {
            vk = vk.ToLower();

            if (vk.Contains("control"))
                return "control";

            if (vk.Contains("menu"))
                return "menu";

            if (vk.Contains("shift"))
                return "shift";

            if (vk.Contains("cancel"))
                return "pause";

            return vk;
        }

        private static bool IsShortcutComplete()
        {
            if (keysHeld.Count == shortcutKeys.Count)
            {
                bool compl = false;

                foreach (string key in shortcutKeys)
                    compl = (keysHeld.Contains(key));

                return compl;
            }
            else return false;
        }
    }
}
