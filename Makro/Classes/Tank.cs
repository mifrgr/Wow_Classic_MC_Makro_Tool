using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Makro.Classes
{
    internal class Tank
    {
        public string Name { get; set; }
        public bool IsMT { get; set; }

        public Tank(string name)
        {
            Name = name;
        }
    }
}
