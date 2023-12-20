using Raid_Tool.Handler;
using Raid_Tool.Makro;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raid_Tool.Classes_Roles;

namespace Raid_Tool.RaidSetups
{
    static class Raid_Setup
    {
        public static string Einteilung(ListHandler listhandler, Role role, byte amount, bool MTneed = false)
        {
            FillMakroList(listhandler, role, amount,0, MTneed);
            return Makro_Handler.MakeMakro();

        }
        public static string Einteilung(ListHandler listhandler, Role role, byte amount, Role role1, byte amount1, bool MTneed = false)
        {
            FillMakroList(listhandler, role, amount,0, MTneed);
            FillMakroList(listhandler, role1, amount1, amount);
            return Makro_Handler.MakeMakro();
        }
        public static string Einteilung(ListHandler listhandler, Role role, byte amount, Role role1, byte amount1, Role role2, byte amount2, bool MTneed = false)
        {
            FillMakroList(listhandler, role, amount, 0, MTneed);
            FillMakroList(listhandler, role1, amount1, amount);
            FillMakroList(listhandler, role2, amount2, (byte)(amount + amount1));
            return Makro_Handler.MakeMakro();
        }
        public static string Einteilung(ListHandler listhandler, Role role, byte amount, Role role1, byte amount1, Role role2, byte amount2, Role role3, byte amount3, bool MTneed = false)
        {
            FillMakroList(listhandler, role, amount, 0, MTneed);
            FillMakroList(listhandler, role1, amount1, amount);
            FillMakroList(listhandler, role2, amount2, (byte)(amount + amount1));
            FillMakroList(listhandler, role3, amount3, (byte)(amount + amount1 + amount2));
            return Makro_Handler.MakeMakro();
        }

        static void FillMakroList(ListHandler listhandler, Role role, byte amount, byte startindex, bool MTneed = false)
        {
            if(MTneed)
            {
                foreach (Tank tank in listhandler.TanksList)
                {

                    if (tank.IsMT)
                    {
                        Makro_Handler.EntryList.Add(new Entry(Role.Tank, Symbol.Boss, tank.Name));
                    }

                }
                if(Makro_Handler.EntryList.Count == 0)
                {
                    throw new Exception("Bitte wählen Sie einen Maintank aus!");
                }

            }
            for (int i = 0; i < amount; i++)
            {
                switch (role)
                {
                    case Role.Tank:
                        {
                            if (listhandler.TanksList.Count < amount+1)
                                throw new Exception("Zu wenig Tanks in der Liste!");

                            if(listhandler.TanksList[i].IsMT || Makro_Handler.EntryList.Exists(entry => entry.Name == listhandler.TanksList[i].Name))
                            {
                                Makro_Handler.EntryList.Add(new Entry(Role.Tank, (Symbol)i + startindex, listhandler.TanksList[i+1].Name));
                            }
                            else
                                Makro_Handler.EntryList.Add(new Entry(Role.Tank, (Symbol)i + startindex, listhandler.TanksList[i].Name));
                            break;
                        }
                    case Role.Mage:
                        {
                            Makro_Handler.EntryList.Add(new Entry(Role.Mage, (Symbol)i + startindex, listhandler.MageList[i].Name));
                            break;
                        }
                    case Role.Kicker:
                        {
                            Makro_Handler.EntryList.Add(new Entry(Role.Kicker, (Symbol)i, listhandler.KickerList[i].Name));
                            break;
                        }
                    case Role.Warlock:
                        {
                            Makro_Handler.EntryList.Add(new Entry(Role.Warlock, (Symbol)i + startindex, listhandler.WarlockList[i].Name));
                            break;
                        }
                }

            }
        }
    }
}
