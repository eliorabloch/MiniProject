using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    class Configuration
    {
        public static string TypeDAL = ConfigurationSettings.AppSettings.Get("TypeDS");
    }

}
