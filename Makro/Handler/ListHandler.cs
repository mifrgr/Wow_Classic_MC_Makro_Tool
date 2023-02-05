using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raid_Tool.Makro;
using Raid_Tool.Classes_Roles;

namespace Raid_Tool.Handler
{

    internal class ListHandler
    {

        public List<Tank> TanksList { get; set; } = new List<Tank>();
        public List<Mage> MageList { get; set; } = new List<Mage>();
        public List<Kicker> KickerList { get; set; } = new List<Kicker>();
        public List<Warlock> WarlockList { get; set; } = new List<Warlock>();
        public List<Dispeller> DispellerList { get; set; } = new List<Dispeller>();

        public Dictionary<Role, byte> CustomMakro { get; set; } = new Dictionary<Role, byte>();

        public void FillList(List<Player> players)
        {
            ClearLists();
            foreach (var item in players)
            {
                switch (item.Class)
                {
                    case "Tank":
                        {
                            TanksList.Add(new Tank(item.Name,Role.Tank));
                            break;
                        }
                    case "Mage":
                        {
                            if (MageList.Count < 6)
                            {
                                MageList.Add(new Mage(item.Name));
                            }
                            else
                                DispellerList.Add(new Dispeller(item.Name));
                            break;
                        }
                    case "Warlock":
                        {
                            WarlockList.Add(new Warlock(item.Name));
                            break;
                        }
                    case "Rogue":
                        {
                            if (KickerList.Count < 6)
                            {
                                KickerList.Add(new Kicker(item.Name));
                            }
                            break;
                        }

                    case "Warrior":
                        {
                            if (KickerList.Count < 6)
                            {
                                KickerList.Add(new Kicker(item.Name));
                            }
                            else
                                TanksList.Add(new Tank(item.Name,Role.Warrior));
                            break;
                        }
                    case "Paladin":
                        {
                            if (item.Spec == "Holy1")
                            {
                                DispellerList.Add(new Dispeller(item.Name));
                            }
                            break;
                        }
                }
            }
            TanksList = TanksList.OrderBy(Tank => Tank.Role).ToList();
        }

        void ClearLists()
        {
            TanksList.Clear();
            MageList.Clear();
            WarlockList.Clear();
            KickerList.Clear();
            DispellerList.Clear();
        }

    }


}
