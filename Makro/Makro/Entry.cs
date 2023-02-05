using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raid_Tool.Classes_Roles;
using Raid_Tool.RaidSetups;

namespace Raid_Tool.Makro
{
    internal class Entry
    {
        public Role Role { get; set; }
        public Symbol Symbol { get; set; }
        public string Name { get; set; }

        public Entry(Role role, Symbol symbol, string name)
        {
            Role = role;
            Symbol = symbol;
            Name = name;
        }
    }
}
