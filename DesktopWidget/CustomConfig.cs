using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopWidget
{
    public class CustomConfig
    {
        private string config_name = "config.cfg";
        private string config_version = "1.0";
        private Dictionary<string, object> ConfigValues = new Dictionary<string, object>();

        public string LoadedConfigVersion = "Unknown";

        public CustomConfig()
        {
            if (!Directory.Exists(this.ConfigPath))
                Directory.CreateDirectory(this.ConfigPath);

            if (!File.Exists(this.ConfigFilePath))
                this.CreateConfigFile();
            else
                this.LoadConfigValues();
        }

        public void LoadConfigValues()
        {
            using (FileStream fileStream = new FileStream(this.ConfigFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (StreamReader streamReader = new StreamReader(fileStream))
                {
                    string line;

                    while (!streamReader.EndOfStream)
                    {
                        line = streamReader.ReadLine();

                        if (line.StartsWith("["))
                            this.LoadedConfigVersion = Regex.Match(line, @"(?!\[)(.+)(?=\])").Value;
                        else if (!line.StartsWith(";"))
                        {
                            var type = this.ConvertType(line[0], Regex.Match(line, @"(?=\=)(.+)(?=\b)").Value.Substring(1));
                            this.ConfigValues.Add(Regex.Match(line, @"(.+)(?=\=)").Value.Substring(1), type);
                        }
                    }
                }
            }
        }

        private void CreateConfigFile()
        {
            this.AddAssemblyItem(this.config_version);

            this.AddConfigItem("TestVariable", true);
        }

        private void AddAssemblyItem(string str)
        {
            using (StreamWriter w = File.AppendText(this.ConfigFilePath))
                w.WriteLine($"[{str}]");
        }

        private void AddConfigItem(string variableName, object value, string commentBefore = "")
        {
            char type = value.GetType().Name.ToLower()[0];

            using (StreamWriter w = File.AppendText(this.ConfigFilePath))
            {
                if (commentBefore != "")
                    w.WriteLine($"; {commentBefore}");

                w.WriteLine($"{type}{variableName}={value}");
            }
        }

        private object ConvertType(char c, object obj)
        {
            switch (c)
            {
                case 'b':
                    return bool.Parse(obj.ToString());
            }

            Debug.WriteLine($"{c}=??? -- obj: {obj.ToString()}");

            return obj;
        }

        public string ConfigPath
        {
            get
            {
                string appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                return Path.Combine(appdata, Application.ProductName);
            }
        }

        public string ConfigFilePath
        {
            get
            {
                return Path.Combine(this.ConfigPath, this.config_name);
            }
        }
    }
}
