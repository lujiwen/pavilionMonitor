using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace PavilionMonitor.Utils
{
    public class Utils
    {
        public static string readConfig(string key)
        {
            Configuration config;
            setConfigFile("app.config");
            config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            String flag = config.AppSettings.Settings[key].Value;
            return flag;
        }
        public static void setConfigFile(string configFileName)
        {
            String path = System.Environment.CurrentDirectory;
            String configFile = path + @"\" + configFileName + "";
            AppDomain.CurrentDomain.SetData("APP_CONFIG_FILE", configFile);
        }

    }
}
