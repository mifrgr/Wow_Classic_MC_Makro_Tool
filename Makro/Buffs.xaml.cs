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

namespace Makro
{
    /// <summary>
    /// Interaktionslogik für _20er.xaml
    /// </summary>
    public partial class Buffs : Window
    {
        public Buffs()
        {
            InitializeComponent();
        }

        private void ResetPriest_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ResetMage_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ResetDruid_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DruidBuff_Click(object sender, RoutedEventArgs e)
        {
            
            if(_20er.IsChecked == true)
            {

                switch(FillList('D', 20))
                {
                    case 1:
                        string BuffString1 = Druid1.Text + " Gruppe 1-4";
                        Clipboard.SetText(BuffString1);
                        break;
                    case 2:
                        string BuffString2 = Druid1.Text + " Gruppe 1-2" + Environment.NewLine + Druid2.Text + " Gruppe 3-4";
                        Clipboard.SetText(BuffString2);
                        break;
                    case 3:
                        string BuffString3 = Druid1.Text + " Gruppe 1-2" + Environment.NewLine + Druid2.Text + " Gruppe 3" + Environment.NewLine + Druid3.Text + " Gruppe 4";
                        Clipboard.SetText(BuffString3);
                        break;
                    case 4:
                        string BuffString4 = Druid1.Text + " Gruppe 1" + Environment.NewLine + Druid2.Text + " Gruppe 2" + Environment.NewLine + Druid3.Text + " Gruppe 3" + Environment.NewLine + Druid2.Text + " Gruppe 4";
                        Clipboard.SetText(BuffString4);
                        break;


                }
            }
        }

        private void MageBuff_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PriestBuff_Click(object sender, RoutedEventArgs e)
        {

        }

        byte FillList(char c,byte raidSize)
        {
            byte returnval = 0;

            if(c == 'D' && raidSize == 20)
            {
                if (Druid1.Text != "")
                    returnval++;
                if (Druid2.Text != "")
                    returnval++;
                if (Druid3.Text != "")
                    returnval++;
                if (Druid4.Text != "")
                    returnval++;
 
            }
            return returnval;

        }
    }
}
