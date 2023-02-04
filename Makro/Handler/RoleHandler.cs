using Raid_Tool.RaidSetups;
using Raid_Tool.Classes_Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raid_Tool.Handler
{
    public enum Role
    {
        Tank = 1,
        Heal = 2,
        Mage = 3,
        Kicker = 4,
        Warlock = 5,
    }


    internal class RoleHandler
    {
        public int HasRaidEnough(List<Tank> tanks, byte amount)
        {
            if (tanks.Count >= amount)
                return amount;
            else return tanks.Count;
        }
        public int HasRaidEnough(List<Mage> Mage, byte amount)
        {
            if (Mage.Count >= amount)
                return amount;
            else return Mage.Count;
        }
        public int HasRaidEnough(List<Kicker> Kicker, byte amount)
        {
            if (Kicker.Count >= amount)
                return amount;
            else return Kicker.Count;
        }
        public int HasRaidEnough(List<Warlock> warlocks, byte amount)
        {
            if (warlocks.Count >= amount)
                return amount;
            else return warlocks.Count;
        }


    }
}
