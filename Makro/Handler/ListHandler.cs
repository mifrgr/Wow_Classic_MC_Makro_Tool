using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Makro.Classes;

namespace Makro.Handler
{

    internal class ListHandler
    {

        public List<Tank> TanksList { get; set; } = new List<Tank>();
        public List<Mage> MageList { get; set; } = new List<Mage>();
        public List<Rouge> RougeList { get; set; } = new List<Rouge>();
        public List<Warlock> WarlockList { get; set; } = new List<Warlock>();

        public void FillList(List<Player> players)
        {
            foreach(var item in players) 
            {
                switch(item.Class)
                {
                    case "Tank":
                        {
                            TanksList.Add(new Tank(item.Name));
                            break;
                        }
                    case "Mage":
                        {
                            MageList.Add(new Mage(item.Name));
                            break;
                        }
                    case "Warlock":
                        {
                            WarlockList.Add(new Warlock(item.Name));
                            break;
                        }
                    case "Rogue":
                        {
                            RougeList.Add(new Rouge(item.Name));
                            break;
                        }
                }
            }
            
        }

    }


}
