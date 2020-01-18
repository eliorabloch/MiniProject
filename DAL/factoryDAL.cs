using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class factoryDAL
    {
        public static IDAL GetDAL(string typeDAL)
        {
            switch (typeDAL)
            {
                case "List": return imp_Dal.getInstance();
                case "XML": return imp_XML_Dal.getInstance();
                //  case "XML": return DAL_XML.Instance;
                default: return null;
            }
        }
    }
}
