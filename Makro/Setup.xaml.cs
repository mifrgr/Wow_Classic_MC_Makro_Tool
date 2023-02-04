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
using Raid_Tool.Json;
using Raid_Tool;
using Raid_Tool.RaidSetups;
using Raid_Tool.Handler;

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
            Role1.ItemsSource = Enum.GetValues(typeof (Role)).Cast<Role>().ToList();
            Role2.ItemsSource = Enum.GetValues(typeof(Role)).Cast<Role>().ToList();
            Role3.ItemsSource = Enum.GetValues(typeof(Role)).Cast<Role>().ToList();
            Role4.ItemsSource = Enum.GetValues(typeof(Role)).Cast<Role>().ToList();
            Role5.ItemsSource = Enum.GetValues(typeof(Role)).Cast<Role>().ToList();
        }

        private void FillLists()
        {
            listHandler.FillList(RaidSignup);
            Tanks.ItemsSource = listHandler.TanksList;
            Tanks.IsReadOnly = false;
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
            //var selected = MC_Einteilungen.SelectedItem;
            //MC_Einteilungen.SelectedItem = null;
            //MC_Einteilungen.SelectedItem = selected;
            try
            {
                Clipboard.Clear();
                Clipboard.SetText(makroText);
            }
            catch(Exception ex)
            { 
                Console.WriteLine(ex.Message); 
            }
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
            int retval = roleHandler.HasRaidEnough(listHandler.TanksList, 5);

            if (retval == 5)
            {
                makroText = "";
                makroText = Raid_Setup.Einteilung(listHandler, Role.Tank, 5);
            }
            else Statusleiste.Content = retval + " von 5 Tanks eingeteilt";
        }

        private void Sulfuron_Selected(object sender, RoutedEventArgs e)
        {
            int retvalTank = roleHandler.HasRaidEnough(listHandler.TanksList, 4);
            int retvalKick = roleHandler.HasRaidEnough(listHandler.KickerList, 4);

            if (retvalTank == 4 && retvalKick == 4)
            {
                makroText = "";
                makroText = Raid_Setup.Einteilung(listHandler, Role.Tank, 4, Role.Kicker, 4);
            }

            else Statusleiste.Content = retvalTank + "/4 Tanks eingeteilt, " + retvalKick + "/4 Kicker."; 
        }

        private void Majordomus_Selected(object sender, RoutedEventArgs e)
        {
            int retvalTank = roleHandler.HasRaidEnough(listHandler.TanksList, 4);
            int retvalMage = roleHandler.HasRaidEnough(listHandler.MageList, 4);

            if (retvalTank == 4 && retvalMage == 4 )
            {
                makroText = "";
                makroText = Raid_Setup.Einteilung(listHandler, Role.Tank, 4, Role.Mage, 4);
            }
        }

        private void Garr_Selected(object sender, RoutedEventArgs e)
        {
            if((listHandler.WarlockList.Count + listHandler.TanksList.Count) >= 8)
            {
                makroText = "";
                makroText = Raid_Setup.Einteilung(listHandler, Role.Warlock, (byte)listHandler.WarlockList.Count, Role.Tank, (byte)(8 - listHandler.WarlockList.Count));
            }
        }

        private void SetCustomMakro_Click(object sender, RoutedEventArgs e)
        {
            switch(listHandler.CustomMakro.Count)
            {
                case 1:
                    {
                        makroText = Raid_Setup.Einteilung(listHandler, listHandler.CustomMakro.First().Key, listHandler.CustomMakro.First().Value);
                        break;
                    }
                case 2:
                    {
                        makroText = Raid_Setup.Einteilung(listHandler, listHandler.CustomMakro.First().Key, listHandler.CustomMakro.First().Value,listHandler.CustomMakro.ElementAt(1).Key, listHandler.CustomMakro.ElementAt(1).Value);
                        break;
                    }
                case 3:
                    {
                        makroText = Raid_Setup.Einteilung(listHandler, listHandler.CustomMakro.First().Key, listHandler.CustomMakro.First().Value, listHandler.CustomMakro.ElementAt(1).Key, listHandler.CustomMakro.ElementAt(1).Value, listHandler.CustomMakro.ElementAt(2).Key, listHandler.CustomMakro.ElementAt(2).Value);
                        break;
                    }
                    case 4:
                    {
                        makroText = Raid_Setup.Einteilung(listHandler, listHandler.CustomMakro.First().Key, listHandler.CustomMakro.First().Value, listHandler.CustomMakro.ElementAt(1).Key, listHandler.CustomMakro.ElementAt(1).Value, listHandler.CustomMakro.ElementAt(2).Key, listHandler.CustomMakro.ElementAt(2).Value, listHandler.CustomMakro.ElementAt(3).Key, listHandler.CustomMakro.ElementAt(3).Value);
                        break;
                    }
            }
            Clipboard.SetText(makroText);
        }


        private void Count_Role1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(Role1.SelectedItem == null && Count_Role1.Text != "")
            {
                MessageBox.Show("Bitte erst eine Rolle auswählen");
                Count_Role1.Text = "";
            }
            if(Count_Role1.Text != "")
            {
                if (listHandler.CustomMakro.ContainsKey((Role)Role1.SelectedItem))
                {
                    listHandler.CustomMakro.Remove((Role)Role1.SelectedItem);
                }

                listHandler.CustomMakro.Add((Role)Role1.SelectedItem, byte.Parse(Count_Role1.Text));
            }
               
        }

        private void Count_Role2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Role2.SelectedItem == null && Count_Role2.Text != "")
            {
                MessageBox.Show("Bitte erst eine Rolle auswählen");
                Count_Role2.Text = "";
            }
            if (Count_Role2.Text != "")
            {
                if (listHandler.CustomMakro.ContainsKey((Role)Role2.SelectedItem))
                {
                    listHandler.CustomMakro.Remove((Role)Role2.SelectedItem);
                }

                listHandler.CustomMakro.Add((Role)Role2.SelectedItem, byte.Parse(Count_Role2.Text));
            }
        }

        private void Count_Role3_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Role3.SelectedItem == null && Count_Role3.Text != "")
            {
                MessageBox.Show("Bitte erst eine Rolle auswählen");
                Count_Role3.Text = "";
            }
            if (Count_Role3.Text != "")
            {
                    if (listHandler.CustomMakro.ContainsKey((Role)Role3.SelectedItem))
                    {
                        listHandler.CustomMakro.Remove((Role)Role3.SelectedItem);
                    }

                    listHandler.CustomMakro.Add((Role)Role3.SelectedItem, byte.Parse(Count_Role3.Text));
            }
        }

        private void Count_Role4_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Role4.SelectedItem == null && Count_Role4.Text != "")
            {
                MessageBox.Show("Bitte erst eine Rolle auswählen");
                Count_Role4.Text = "";
            }
            if (Count_Role4.Text != "")
                {
                if (listHandler.CustomMakro.ContainsKey((Role)Role4.SelectedItem))
                {
                    listHandler.CustomMakro.Remove((Role)Role4.SelectedItem);
                }
                listHandler.CustomMakro.Add((Role)Role4.SelectedItem, byte.Parse(Count_Role4.Text));
            }
        }

        private void Count_Role5_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Role5.SelectedItem == null && Count_Role5.Text != "")
            {
                MessageBox.Show("Bitte erst eine Rolle auswählen");
                Count_Role5.Text = "";
            }
            if (Count_Role5.Text != "")
                {
                if (listHandler.CustomMakro.ContainsKey((Role)Role5.SelectedItem))
                {
                    listHandler.CustomMakro.Remove((Role)Role5.SelectedItem);
                }
                listHandler.CustomMakro.Add((Role)Role5.SelectedItem, byte.Parse(Count_Role5.Text));
            }
        }
    }
}

