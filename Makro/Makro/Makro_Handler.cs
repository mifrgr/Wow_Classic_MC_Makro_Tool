using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace Raid_Tool.Makro
{
    static class Makro_Handler
    {
        public static List<Entry> EntryList = new List<Entry>();

        public static string MakeMakro()
        {
            string makro = "";

            foreach(Entry entry in EntryList)
            {
                makro+= "/ra {" + entry.Symbol.ToString() +"} " + entry.Role.ToString() + " : " +entry.Name + Environment.NewLine;
            }
            return makro;
        }
    }
}
