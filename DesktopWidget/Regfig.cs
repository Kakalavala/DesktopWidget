using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopWidget
{
    public class Regfig
    {
        private RegistryKey rk;
        private Dictionary<string, object> _values = new Dictionary<string, object>();

        public Regfig()
        {
            this.rk = Registry.CurrentUser.OpenSubKey($"SOFTWARE\\{Application.ProductName}", true);

            if (this.rk == null || this.rk.GetValueNames().Length == 0)
            {
                rk = Registry.CurrentUser.CreateSubKey($"SOFTWARE\\{Application.ProductName}");
                this.RestoreDefaults();

                foreach (KeyValuePair<string, object> kvp in this._values)
                    this.SetVariable(kvp.Key, kvp.Value, true);
            }
        }

        public void RestoreDefaults()
        {
            this._values.Clear();
            
            this._values.Add("AllowLogging", true);
            this._values.Add("AllowDisposal", true);
            this._values.Add("AllowShortcut", true);
            this._values.Add("AllowStartup", true);
            this._values.Add("Remember", false);
            this._values.Add("ShowSeconds", false);
            this._values.Add("ShowIntStatus", true);
            this._values.Add("ShowSideButtons", true);
            this._values.Add("WidgetPosition", 0);
            this._values.Add("TimeFormat", 2);
            this._values.Add("DateFormat", 7);
            this._values.Add("Shortcut", 2);
            this._values.Add("DisplaySelected", 1);
            this._values.Add("ThemeColor", -1);
        }

        public string GetString(string name)
        {
            return this.GetVariableValue(name).ToString();
        }

        public bool GetBool(string name)
        {
            return ((byte)this.GetVariableValue(name) == 0) ? false : true;
        }

        public int GetInt(string name)
        {
            return (int)this.GetVariableValue(name);
        }

        public object GetVariableValue(string name)
        {
            name = name.ToLower();

            switch (rk.GetValueKind(name))
            {
                case RegistryValueKind.Binary:
                    return ((byte[])rk.GetValue(name))[0];
                case RegistryValueKind.DWord:
                    return (int)rk.GetValue(name);
                default:
                case RegistryValueKind.String:
                    return rk.GetValue(name).ToString();
            }

        }

        public bool SetVariable(string name, object value, bool overwrite = true)
        {
            name = name.ToLower();

            bool WriteVar()
            {
                RegistryValueKind type;

                switch (value.GetType().Name)
                {
                    case "Boolean":
                        type = RegistryValueKind.Binary;
                        value = ((bool)value) ? new byte[] { 1 } : new byte[] { 0 };
                        break;
                    case "Int32":
                        type = RegistryValueKind.DWord;
                        break;
                    default:
                    case "String":
                        type = RegistryValueKind.String;
                        break;
                }

                rk.SetValue(name, value, type);
                return true;
            }

            if (rk.GetValue(name) == null)
                return WriteVar();
            else
            {
                if (overwrite)
                    return WriteVar();
                else return false;
            }
        }

        public bool RemoveVariable(string name)
        {
            name = name.ToLower();

            if (rk.GetValue(name) != null)
            {
                rk.DeleteValue(name);
                return true;
            }
            else return false;
        }
    }
}
