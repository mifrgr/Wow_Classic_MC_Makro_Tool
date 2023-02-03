using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace Makro.Handler
{
    public enum Role
    {
        Tank = 1,
        Heal = 2,
        Mage = 3,
        Rouge = 4,
        Warlock = 5,
    }

    internal class RoleHandler
    {
        public bool HasRaidEnoughClass(Role role, byte amount)
        {
            switch (role)
            {


            }

            return true;
        }
    }
}
