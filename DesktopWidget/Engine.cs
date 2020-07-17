using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.NetworkInformation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Diagnostics;

namespace DesktopWidget
{
    public static class Engine
    {
        private static string APPDATA = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        private static string LOG_PATH = Path.Combine(Path.Combine(APPDATA, Application.ProductName), "logs");

        public static string ColorToHex(Color col)
        {
            return $"{col.R.ToString("X2")}{col.G.ToString("X2")}{col.B.ToString("X2")}";
        }

        public static Color ColorFromHex(string hex)
        {
            int rgb = Convert.ToInt32(hex, 16);

            int r = (rgb & 0xff0000) >> 16;
            int g = (rgb & 0xff00) >> 8;
            int b = (rgb & 0xff);

            return Color.FromArgb(255, r, g, b);
        }

        public static void DrawGroupBox(Color backColor, GroupBox box, Graphics g, Color textColor, Color borderColor)
        {
            if (box != null)
            {
                Brush textBrush = new SolidBrush(textColor);
                Brush borderBrush = new SolidBrush(borderColor);
                Pen borderPen = new Pen(borderBrush);
                SizeF strSize = g.MeasureString(box.Text, box.Font);
                Rectangle rect = new Rectangle(box.ClientRectangle.X,
                                               box.ClientRectangle.Y + (int)(strSize.Height / 2),
                                               box.ClientRectangle.Width - 1,
                                               box.ClientRectangle.Height - (int)(strSize.Height / 2) - 1);

                // Clear text and border
                g.Clear(backColor);

                // Draw text
                g.DrawString(box.Text, box.Font, textBrush, box.Padding.Left, 0);

                // Drawing Border
                //Left
                g.DrawLine(borderPen, rect.Location, new Point(rect.X, rect.Y + rect.Height));
                //Right
                g.DrawLine(borderPen, new Point(rect.X + rect.Width, rect.Y), new Point(rect.X + rect.Width, rect.Y + rect.Height));
                //Bottom
                g.DrawLine(borderPen, new Point(rect.X, rect.Y + rect.Height), new Point(rect.X + rect.Width, rect.Y + rect.Height));
                //Top1
                g.DrawLine(borderPen, new Point(rect.X, rect.Y), new Point(rect.X + box.Padding.Left, rect.Y));
                //Top2
                g.DrawLine(borderPen, new Point(rect.X + box.Padding.Left + (int)(strSize.Width), rect.Y), new Point(rect.X + rect.Width, rect.Y));
            }
        }

        public static void AddToolTip(Control cont, string txt)
        {
            (new ToolTip()).SetToolTip(cont, txt);
        }

        public static int GetWidgetPosition()
        {
            Properties.Settings.Default.Reload();
            return Properties.Settings.Default.WidgetPosition;
        }

        public static void SetWidgetPosition(int pos)
        {
            if (pos > 3 || pos < 0)
                pos = 0;

            Properties.Settings.Default.WidgetPosition = pos;
            Properties.Settings.Default.Save();
            Properties.Settings.Default.Reload();
        }

        public static int KillTasks()
        {
            int count = 0;

            foreach (Process pro in Process.GetProcesses())
            {
                if (!pro.Responding)
                {
                    if (pro.Threads[0].ThreadState == ThreadState.Running)
                    {
                        count += 1;
                        pro.Kill();
                    }
                }
            }

            return count;
        }

        public static void FadeIn(Form f, byte steps)
        {
            float sval = (float)(steps / 100f);
            float fOpacity = 0f;

            for (byte b = 0; b < steps; b += 1)
            {
                f.Opacity = fOpacity / 100f;
                f.Refresh();

                fOpacity += sval;
            }
        }

        public static void FadeOut(Form f, byte steps)
        {
            float sval = (float)(100f / steps);
            float fOpacity = 100f;

            for (byte b = 0; b < steps; b += 1)
            {
                f.Opacity = fOpacity / 100f;
                f.Refresh();
                
                fOpacity -= sval;
            }
        }

        public static Image TintImage(Image img, Color color)
        {
            Bitmap bmp = new Bitmap(img);
            Bitmap new_bmp = new Bitmap(img.Width, img.Height);

            for (int x = 0; x < bmp.Width; x += 1)
            {
                for (int y = 0; y < bmp.Height; y += 1)
                {
                    new_bmp.SetPixel(x, y, Color.FromArgb(bmp.GetPixel(x, y).A, color.R, color.G, color.B));
                }
            }

            return new_bmp as Image;
        }

        public static bool DoesDirectoryExist()
        {
            return Properties.Settings.Default.AllowLogging && Directory.Exists(LOG_PATH);
        }

        public static bool DoesCurrentLogExist()
        {
            TimeStamp ts = new TimeStamp();
            string path = Path.Combine(LOG_PATH, $"{ts.FileStamp}.log");

            return Properties.Settings.Default.AllowLogging && (DoesDirectoryExist() && File.Exists(path));
        }

        public static void OpenLogsDirectory()
        {
            CreateLogFilesIfNecessary();

            Process.Start(new ProcessStartInfo(LOG_PATH, "explorer.exe"));
        }

        public static void OpenCurrentLog()
        {
            TimeStamp ts = new TimeStamp();
            string path = Path.Combine(LOG_PATH, $"{ts.FileStamp}.log");

            if (Directory.Exists(LOG_PATH) && File.Exists(path))
                Process.Start(path);
        }

        private static void CreateLogFilesIfNecessary()
        {
            if (Properties.Settings.Default.AllowLogging && !Directory.Exists(LOG_PATH))
                Directory.CreateDirectory(LOG_PATH);
        }

        public static void Log(string logtxt)
        {
            if (Properties.Settings.Default.AllowLogging)
            {
                TimeStamp ts = new TimeStamp();
                string path = Path.Combine(LOG_PATH, $"{ts.FileStamp}.log");

                CreateLogFilesIfNecessary();

                using (StreamWriter w = File.AppendText(path))
                    w.WriteLine($"{ts.Stamp} {logtxt}");
            }
        }

        public static void Log(List<string> logtxt)
        {
            if (Properties.Settings.Default.AllowLogging)
            {
                TimeStamp ts = new TimeStamp();
                string path = Path.Combine(LOG_PATH, $"{ts.FileStamp}.log");

                CreateLogFilesIfNecessary();

                using (StreamWriter w = File.AppendText(path))
                {
                    foreach (string str in logtxt)
                        w.WriteLine($"{ts.Stamp} {str}");
                }
            }
        }

        public static void DeleteLogs()
        {
            if (Directory.Exists(LOG_PATH))
            {
                foreach (string fl in Directory.GetFiles(LOG_PATH))
                {
                    File.Delete(fl);
                }

                Directory.Delete(LOG_PATH);
            }
        }
    }

    public class TimeStamp
    {
        public DateTime DateTimeObject { get; private set; }
        public bool IsAm { get; private set; }
        public string Time12 { get; private set; }
        public string Time24 { get; private set; }
        public string FullDate { get; private set; }
        public string WeekDay { get; private set; }
        public string Month { get; private set; }
        public string Day { get; private set; }
        public string Stamp { get; private set; }
        public string FileStamp { get; private set; }

        public TimeStamp()
        {
            DateTime dt = DateTime.Now;

            this.DateTimeObject = dt;

            this.IsAm = (dt.Hour < 12);
            this.Time12 = dt.ToString("h:mm");
            this.Time24 = dt.ToString("HH:mm");
            this.FullDate = dt.ToString("MM/dd/yyyy");
            this.WeekDay = dt.ToString("ddd.");
            this.Month = dt.ToString("MMM.");
            this.Stamp = dt.ToString("[MM/dd - HH:mm:ss]");
            this.FileStamp = dt.ToString("yyyy-MM-dd");

            switch (dt.Day)
            {
                case 1:
                case 21:
                case 31:
                    this.Day = $"{dt.Day}st";
                    break;
                case 2:
                case 22:
                    this.Day = $"{dt.Day}nd";
                    break;
                case 3:
                case 23:
                    this.Day = $"{dt.Day}rd";
                    break;
                default:
                    this.Day = $"{dt.Day}th";
                    break;
            }
        }
    }

    public struct Connection
    {
        public NetworkInterfaceType ConnectionType { get; private set; }
        public bool HasConnection { get; private set; }
        public bool IsEthernetConnection { get; private set; }
        public string NetworkName { get; private set; }

        public Connection(string name, NetworkInterfaceType type, bool connection)
        {
            this.ConnectionType = type;
            this.HasConnection = connection;
            this.IsEthernetConnection = (type.ToString().Contains("Ethernet"));
            this.NetworkName = name;
        }
    }

    public static class ThemeInfo
    {
        [DllImport("uxtheme.dll", EntryPoint = "#95")]
        public static extern uint GetImmersiveColorFromColorSetEx(uint dwImmersiveColorSet, uint dwImmersiveColorType, bool bIgnoreHighContrast, uint dwHighContrastCacheMode);
        [DllImport("uxtheme.dll", EntryPoint = "#96")]
        public static extern uint GetImmersiveColorTypeFromName(IntPtr pName);
        [DllImport("uxtheme.dll", EntryPoint = "#98")]
        public static extern int GetImmersiveUserColorSetPreference(bool bForceCheckRegistry, bool bSkipCheckOnFail);

        public static Color GetThemeColor(int offset = 0)
        {
            var colorSetEx = GetImmersiveColorFromColorSetEx(
                (uint)GetImmersiveUserColorSetPreference(false, false),
                GetImmersiveColorTypeFromName(Marshal.StringToHGlobalUni("ImmersiveStartSelectionBackground")),
                false, 0);

            var colour = Color.FromArgb((byte)((0xFF000000 & colorSetEx) >> 24), (byte)(0x000000FF & colorSetEx) - offset,
                (byte)((0x0000FF00 & colorSetEx) >> 8) - offset, (byte)((0x00FF0000 & colorSetEx) >> 16) - offset);

            return colour;
        }
    }
}
