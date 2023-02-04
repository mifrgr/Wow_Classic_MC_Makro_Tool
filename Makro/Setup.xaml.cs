using System;
using System.Collections.Generic;
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
using System.IO;
using Microsoft.Win32;
using System.Diagnostics;
using Makro.Json;
using Makro.Handler;
using Makro.RaidSetups;

namespace Makro
{
    /// <summary>
    /// Interaktionslogik für MC.xaml
    /// </summary>
    public partial class Setup : Window
    {
        public List<Player> RaidSignup = new List<Player>();

        ListHandler listHandler = new();
        RoleHandler roleHandler = new();

        string makroText = "";

      
        public Setup()
        {
            InitializeComponent();

        }

        private void FillLists()
        {
            listHandler.FillList(RaidSignup);
            Tanks.ItemsSource = listHandler.TanksList;
            Mage.ItemsSource = listHandler.MageList;
            Kicker.ItemsSource = listHandler.KickerList;
            Warlock.ItemsSource = listHandler.WarlockList;

        }

        private void ResetTanks_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Willst du wirklich alles zurücksetzen", "Achtung", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {

            }


        }

        private void ResetMage_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Willst du wirklich alles zurücksetzen", "Achtung", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {

            }
        }

        private void ResetRog_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Willst du wirklich alles zurücksetzen", "Achtung", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {

            }
        }

        private void ResetWL_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Willst du wirklich alles zurücksetzen", "Achtung", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
            }
        }


        private void Einteilung_Auswerten_Click(object sender, RoutedEventArgs e)
        {
            FillLists();
            Clipboard.SetText(makroText);

        }



        private void Tank1_LostFocus(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Importieren_Click(object sender, RoutedEventArgs e)
        {
            Json_Handler handler = new Json_Handler();
            handler.Json_import();
            RaidSignup = handler.Json_read();
            FillLists();
        }

        private void MC_Selected(object sender, RoutedEventArgs e)
        {
            MC_Einteilungen.Visibility = Visibility.Visible;
        }

        private void BWL_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void Hunde_Selected(object sender, RoutedEventArgs e)
        {
            if(roleHandler.HasRaidEnough(listHandler.TanksList,5))
            {
                makroText = MC_Setup.Einteilung(listHandler, Role.Tank, 5);
            }

        }

        private void Sulfuron_Selected(object sender, RoutedEventArgs e)
        {
            if(roleHandler.HasRaidEnough(listHandler.TanksList,4) && roleHandler.HasRaidEnough(listHandler.KickerList,4))
            {
                makroText = MC_Setup.Einteilung(listHandler,Role.Tank, 4, Role.Kicker, 4);
            }
        }

        private void Majordomus_Selected(object sender, RoutedEventArgs e)
        {
            if(roleHandler.HasRaidEnough(listHandler.TanksList,4) && roleHandler.HasRaidEnough(listHandler.MageList,4))
            {
                makroText = MC_Setup.Einteilung(listHandler,Role.Tank, 4, Role.Mage, 4);
            }
        }

        private void Garr_Selected(object sender, RoutedEventArgs e)
        {
            if((listHandler.WarlockList.Count + listHandler.TanksList.Count) >= 8)
            {
                makroText = MC_Setup.Einteilung(listHandler, Role.Warlock, (byte)listHandler.WarlockList.Count, Role.Tank, (byte)(8 - listHandler.WarlockList.Count));
            }
        }
    }
}

