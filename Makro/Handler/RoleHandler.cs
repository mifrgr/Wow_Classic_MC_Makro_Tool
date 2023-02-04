using Makro.Classes;
using Makro.RaidSetups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Makro.Handler
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

        public bool HasRaidEnough(List<Tank> tanks, byte amount)
        {
            if (tanks.Count >= amount)
                return true;
            else return false;
        }
        public bool HasRaidEnough(List<Mage> Mage, byte amount)
        {
            if (Mage.Count >= amount)
                return true;
            else return false;
        }
        public bool HasRaidEnough(List<Kicker> Kicker, byte amount)
        {
            if (Kicker.Count >= amount)
                return true;
            else return false;
        }
        public bool HasRaidEnough(List<Warlock> warlocks, byte amount)
        {
            if (warlocks.Count >= amount)
                return true;
            else return false;
        }


    }
}
