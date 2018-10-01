using System;
using System.Configuration;

namespace Tester.Tools
{
    public class ConfigurationFile
    {
        public static Int32 GetPort()
        {
            String port = ConfigurationSettings.AppSettings["Port"];
            return Convert.ToInt32(port);
        }

        public static String GetName()
        {
            return ConfigurationSettings.AppSettings["Name"];
        }

        public static String GetIpAdressManager()
        {
            return ConfigurationSettings.AppSettings["IpAdressManager"];
        }
     
    }
}
