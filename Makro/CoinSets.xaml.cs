using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Raid_Tool.Handler;

namespace Raid_Tool
{
    /// <summary>
    /// Interaktionslogik für CoinSets.xaml
    /// </summary>
    public partial class CoinSets : Window
    {
        TextHandler_Coins handler = new TextHandler_Coins();
        List<CoinEntry> available = new List<CoinEntry>() { new CoinEntry(Coins.Zul, 0), new CoinEntry(Coins.Razz, 0), new CoinEntry(Coins.Hakk, 0), new CoinEntry(Coins.Guru, 0), new CoinEntry(Coins.Vile, 0), new CoinEntry(Coins.Wither, 0), new CoinEntry(Coins.Sand, 0), new CoinEntry(Coins.Skull, 0), new CoinEntry(Coins.Blut, 0)};

        public CoinSets()
        {
            InitializeComponent();
            CoinsAvailable.ItemsSource = available;
        }

        List<CoinEntry> list = new List<CoinEntry>() { new CoinEntry(Coins.Zul, 0), new CoinEntry(Coins.Razz, 0), new CoinEntry(Coins.Hakk, 0), new CoinEntry(Coins.Guru, 0), new CoinEntry(Coins.Vile, 0), new CoinEntry(Coins.Wither, 0), new CoinEntry(Coins.Sand, 0), new CoinEntry(Coins.Skull, 0), new CoinEntry(Coins.Blut, 0) };

        private void Import_Click(object sender, RoutedEventArgs e)
        {
            var list1 = available.Where(entry => entry.Type == Coins.Zul || entry.Type == Coins.Razz || entry.Type == Coins.Hakk).ToList();
            list1.Sort();
            list[0].Amount = list1[0].Amount - available[0].Amount;
            list[1].Amount = list1[0].Amount - available[1].Amount;
            list[2].Amount = list1[0].Amount - available[2].Amount;

            var list2 = available.Where(entry => entry.Type == Coins.Guru || entry.Type == Coins.Vile || entry.Type == Coins.Wither).ToList();
            list2.Sort();
            list[3].Amount = list2[0].Amount - available[3].Amount;
            list[4].Amount = list2[0].Amount - available[4].Amount;
            list[5].Amount = list2[0].Amount - available[5].Amount;

            var list3 = available.Where(entry => entry.Type == Coins.Sand || entry.Type == Coins.Skull || entry.Type == Coins.Blut).ToList();
            list3.Sort();
            list[6].Amount = list3[0].Amount - available[6].Amount;
            list[7].Amount = list3[0].Amount - available[7].Amount;
            list[8].Amount = list3[0].Amount - available[8].Amount;



            NeededCoins.ItemsSource = list;
        }

    }
    public enum Coins
    {
        Zul = 0,
        Razz = 1,
        Hakk = 2,
        Guru = 3,
        Vile = 4,
        Wither = 5,
        Sand = 6,
        Skull = 7,
        Blut = 8,
    }
    class CoinEntry : IComparable<CoinEntry>
    {
        public Coins Type { get; set; }
        public int Amount { get; set; }

        public CoinEntry(Coins type, int amount) 
        {
            Amount = amount;
            Type = type;
        }

        public int CompareTo(CoinEntry other)
        {
            return other.Amount - Amount;
        }
    }
}
