using Makro.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Makro.RaidSetups
{
    static class MC_Setup
    {
        static string ra = "/ra ";
        public static string Einteilung(ListHandler listhandler, Role role, byte amount,bool MTneed = false)
       {
         
            string makro = "";
            if (!MTneed)
            {
                for(int i = 0;i< amount;i++)
                {
                    makro += ra + "{" + ((Symbol)i).ToString() + "} ";
                    makro += listhandler.TanksList[i].Name + Environment.NewLine;
                }
               
            }
            return makro;

            

       }
       public static string Einteilung(ListHandler listhandler, Role role, byte amount, Role role1, byte amount1, bool MTneed = false)
       {
            return "";
       }
       public static string Einteilung(ListHandler listhandler, Role role, byte amount, Role role1, byte amount1, Role role2, byte amount2, bool MTneed = false)
       {
            return "";
       }
        public static string Einteilung(ListHandler listhandler, Role role, byte amount, Role role1, byte amount1, Role role2, byte amount2, Role role3, byte amount3, bool MTneed = false)
        {
            return "";
        }
    }
}
