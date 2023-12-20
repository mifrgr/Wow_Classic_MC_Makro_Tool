using Raid_Tool.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raid_Tool.Classes_Roles
{
    internal class Tank
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsMT { get; set; }
        public Role Role { get; set; }

        public Tank() { }

        public Tank(string name,Role role, int ID)
        {
            Id = ID;
            Name = name;
            Role = role;

        }
    }
}
