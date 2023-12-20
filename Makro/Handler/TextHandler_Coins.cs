using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raid_Tool.Handler
{
    public enum Coins
    {
        Zulianische = 0,
        Razzashi = 1,
        Hakkari = 2,
        Gurubashi = 3,
        Vilebranch = 4,
        Witherbark = 5,
        Sandfury = 6,
        Skullsplitter = 7,
        Blutskalpe = 8,    
    }

    public class CoinEntry
    {
        public Coins Coin { get; set; }
        public int Count { get; set; }


        public CoinEntry(Coins coin, int count)
        {
            Coin = coin;
            Count = count;
        }
    }

    
    internal class TextHandler_Coins
    {
        List<CoinEntry> coinList = new List<CoinEntry>();


      
    }
}
