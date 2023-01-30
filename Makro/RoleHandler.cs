using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Makro
{
    enum Role
    {
        Mage = 1,
        Warlock = 2,
        Rouge = 3,
    }

    internal class RoleHandler
    {
        public bool HasRaidEnoughClass(Role role, byte amount)
        {
            switch (role)
            {
                case Role.Mage:
                    {
                        switch(amount) 
                        {

                        }
                    }
            }

        }
    }
}
