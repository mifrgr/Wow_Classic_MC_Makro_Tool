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

namespace Makro
{
    /// <summary>
    /// Interaktionslogik für _20er.xaml
    /// </summary>
    public partial class Buffs : Window
    {
        string path = "";
        public Buffs()
        {
            InitializeComponent();
        }

        private void ResetPriest_Click(object sender, RoutedEventArgs e)
        {
            Priest1.Text = "";
            Priest2.Text = "";
            Priest3.Text = "";
            Priest4.Text = "";
            Priest5.Text = "";
            Priest6.Text = "";
            Priest7.Text = "";
        }

        private void ResetMage_Click(object sender, RoutedEventArgs e)
        {
            Mage1.Text = "";
            Mage2.Text = "";
            Mage3.Text = "";
            Mage4.Text = "";
            Mage5.Text = "";
            Mage6.Text = "";
            Mage7.Text = "";
        }

        private void ResetDruid_Click(object sender, RoutedEventArgs e)
        {
            Druid1.Text = "";
            Druid2.Text = "";
            Druid3.Text = "";
            Druid4.Text = "";
            Druid5.Text = "";
            Druid6.Text = "";
            Druid7.Text = "";
        }

        private void DruidBuff_Click(object sender, RoutedEventArgs e)
        {
            if(_20er.IsChecked == false & _40er.IsChecked == false)
            {
                MessageBox.Show("Bitte erst einen Raid in der Checkbox auswählen");
                return;
            }
            
            if(_20er.IsChecked == true)
            {

                switch(FillList('D', 20))
                {
                    case 1:
                        string BuffString1 = "/ra " + Druid1.Text + " Gruppe 1-4";
                        Clipboard.SetText(BuffString1);
                        break;
                    case 2:
                        string BuffString2 = "/ra " + Druid1.Text + " Gruppe 1+3" + Environment.NewLine + "/ra " + Druid2.Text + " Gruppe 2+4";
                        Clipboard.SetText(BuffString2);
                        break;
                    case 3:
                        string BuffString3 = "/ra " + Druid1.Text + " Gruppe 1" + Environment.NewLine + "/ra " + Druid2.Text + " Gruppe 2" + Environment.NewLine + "/ra " + Druid3.Text + " Gruppe 3+4";
                        Clipboard.SetText(BuffString3);
                        break;
                    case 4:
                        string BuffString4 = "/ra " + Druid1.Text + " Gruppe 1" + Environment.NewLine + "/ra " + Druid2.Text + " Gruppe 2" + Environment.NewLine + "/ra " + Druid3.Text + " Gruppe 3" + Environment.NewLine + "/ra " + Druid4.Text + " Gruppe 4";
                        Clipboard.SetText(BuffString4);
                        break;


                }
            }
            if (_40er.IsChecked == true)
            {

                switch (FillList('D', 40))
                {
                    case 1:
                        string BuffString1 = "/ra " + Druid1.Text + " Gruppe 1-8";
                        Clipboard.SetText(BuffString1);
                        break;
                    case 2:
                        string BuffString2 = "/ra " + Druid1.Text + " Gruppe 1,3,5,7" + Environment.NewLine + "/ra "  + Druid2.Text + " Gruppe 2,4,6,8";
                        Clipboard.SetText(BuffString2);
                        break;
                    case 3:
                        string BuffString3 = "/ra " + Druid1.Text + " Gruppe 1,3" + Environment.NewLine + "/ra " + Druid2.Text + " Gruppe 2,4 " + Environment.NewLine + "/ra " +Druid3.Text + " Gruppe 5-8";
                        Clipboard.SetText(BuffString3);
                        break;
                    case 4:
                        string BuffString4 = "/ra " + Druid1.Text + " Gruppe 1,3" + Environment.NewLine + "/ra " +Druid2.Text + " Gruppe 2,4" + Environment.NewLine + "/ra " +Druid3.Text + " Gruppe 5-6" + Environment.NewLine + "/ra " +Druid4.Text + " Gruppe 7-8";
                        Clipboard.SetText(BuffString4);
                        break;
                    case 5:
                        string BuffString5 = "/ra " + Druid1.Text + " Gruppe 1" + Environment.NewLine + "/ra " +Druid2.Text + " Gruppe 2" + Environment.NewLine + "/ra " +Druid3.Text + " Gruppe 3-4" + Environment.NewLine + "/ra " +Druid4.Text + " Gruppe 5-6" + Environment.NewLine + "/ra " +Druid5.Text + " Gruppe 7-8";
                        Clipboard.SetText(BuffString5);
                        break;
                    case 6:
                        string BuffString6 = "/ra " + Druid1.Text + " Gruppe 1" + Environment.NewLine + "/ra " +Druid2.Text + " Gruppe 2" + Environment.NewLine + "/ra " +Druid3.Text + " Gruppe 3" + Environment.NewLine + "/ra " +Druid4.Text + " Gruppe 4-5" + Environment.NewLine + "/ra " +Druid5.Text + " Gruppe 6-7" + Environment.NewLine + "/ra " +Druid6.Text + " Gruppe 8";
                        Clipboard.SetText(BuffString6);
                        break;
                    case 7:
                        string BuffString7 = "/ra " + Druid1.Text + " Gruppe 1" + Environment.NewLine + "/ra " +Druid2.Text + " Gruppe 2" + Environment.NewLine + "/ra " +Druid3.Text + " Gruppe 3" + Environment.NewLine + "/ra " +Druid4.Text + " Gruppe 4" + Environment.NewLine + "/ra " +Druid5.Text + " Gruppe 5" + Environment.NewLine + "/ra " +Druid6.Text + " Gruppe 6-7" + Environment.NewLine + "/ra " +Druid6.Text + " Gruppe 8";
                        Clipboard.SetText(BuffString7);
                        break;

                }
            }
        }

        private void MageBuff_Click(object sender, RoutedEventArgs e)
        {
            if (_20er.IsChecked == false & _40er.IsChecked == false)
            {
                MessageBox.Show("Bitte erst einen Raid in der Checkbox auswählen");
                return;
            }

            if (_20er.IsChecked == true)
            {

                switch (FillList('M', 20))
                {
                    case 1:
                        string BuffString1 = "/ra " + Mage1.Text + " Gruppe 1-4";
                        Clipboard.SetText(BuffString1);
                        break;
                    case 2:
                        string BuffString2 = "/ra " + Mage1.Text + " Gruppe 1+3" + Environment.NewLine + "/ra " +Mage2.Text + " Gruppe 2+4";
                        Clipboard.SetText(BuffString2);
                        break;
                    case 3:
                        string BuffString3 = "/ra " + Mage1.Text + " Gruppe 1" + Environment.NewLine + "/ra " +Mage2.Text + " Gruppe 2" + Environment.NewLine + "/ra " +Mage3.Text + " Gruppe 3+4";
                        Clipboard.SetText(BuffString3);
                        break;
                    case 4:
                        string BuffString4 = "/ra " + Mage1.Text + " Gruppe 1" + Environment.NewLine + "/ra " +Mage2.Text + " Gruppe 2" + Environment.NewLine + "/ra " +Mage3.Text + " Gruppe 3" + Environment.NewLine + "/ra " +Mage4.Text + " Gruppe 4";
                        Clipboard.SetText(BuffString4);
                        break;


                }
            }
            if (_40er.IsChecked == true)
            {

                switch (FillList('M', 40))
                {
                    case 1:
                        string BuffString1 = "/ra " + Mage1.Text + " Gruppe 1-8";
                        Clipboard.SetText(BuffString1);
                        break;
                    case 2:
                        string BuffString2 = "/ra " + Mage1.Text + " Gruppe 1,3,5,7" + Environment.NewLine + "/ra " +Mage2.Text + " Gruppe 2,4,6,8";
                        Clipboard.SetText(BuffString2);
                        break;
                    case 3:
                        string BuffString3 = "/ra " + Mage1.Text + " Gruppe 1-3" + Environment.NewLine + "/ra " +Mage2.Text + " Gruppe 4-6 " + Environment.NewLine + "/ra " +Mage3.Text + " Gruppe 7-8";
                        Clipboard.SetText(BuffString3);
                        break;
                    case 4:
                        string BuffString4 = "/ra " + Mage1.Text + " Gruppe 1-2" + Environment.NewLine + "/ra " +Mage2.Text + " Gruppe 3-4" + Environment.NewLine + "/ra " +Mage3.Text + " Gruppe 5-6" + Environment.NewLine + "/ra " +Mage4.Text + " Gruppe 7-8";
                        Clipboard.SetText(BuffString4);
                        break;
                    case 5:
                        string BuffString5 = "/ra " + Mage1.Text + " Gruppe 1-2" + Environment.NewLine + "/ra " +Mage2.Text + " Gruppe 3-4" + Environment.NewLine + "/ra " +Mage3.Text + " Gruppe 5-6" + Environment.NewLine + "/ra " +Mage4.Text + " Gruppe 7" + Environment.NewLine + "/ra " +Mage5.Text + " Gruppe 8";
                        Clipboard.SetText(BuffString5);
                        break;
                    case 6:
                        string BuffString6 = "/ra " + Mage1.Text + " Gruppe 1-2" + Environment.NewLine + "/ra " +Mage2.Text + " Gruppe 3-4" + Environment.NewLine + "/ra " +Mage3.Text + " Gruppe 5" + Environment.NewLine + "/ra " +Mage4.Text + " Gruppe 6" + Environment.NewLine + "/ra " +Mage5.Text + " Gruppe 7" + Environment.NewLine + "/ra " +Mage6.Text + " Gruppe 8";
                        Clipboard.SetText(BuffString6);
                        break;
                    case 7:
                        string BuffString7 = "/ra " + Mage1.Text + " Gruppe 1-2" + Environment.NewLine + "/ra " +Mage2.Text + " Gruppe 3" + Environment.NewLine + "/ra " +Mage3.Text + " Gruppe 4" + Environment.NewLine + "/ra " +Mage4.Text + " Gruppe 5" + Environment.NewLine + "/ra " +Mage5.Text + " Gruppe 6" + Environment.NewLine + "/ra " +Mage6.Text + " Gruppe 7" + Environment.NewLine + "/ra " +Mage7.Text + " Gruppe 8";
                        Clipboard.SetText(BuffString7);
                        break;



                }
            }
          
        }

        private void PriestBuff_Click(object sender, RoutedEventArgs e)
        {
            if (_20er.IsChecked == false & _40er.IsChecked == false)
            {
                MessageBox.Show("Bitte erst einen Raid in der Checkbox auswählen");
                return;
            }

            if (_20er.IsChecked == true)
            {

                switch (FillList('P', 20))
                {
                    case 1:
                        string BuffString1 = "/ra " + Priest1.Text + " Gruppe 1-4";
                        Clipboard.SetText(BuffString1);
                        break;
                    case 2:
                        string BuffString2 = "/ra " + Priest1.Text + " Gruppe 1+3" + Environment.NewLine + "/ra " +Priest2.Text + " Gruppe 2+4";
                        Clipboard.SetText(BuffString2);
                        break;
                    case 3:
                        string BuffString3 = "/ra " + Priest1.Text + " Gruppe 1" + Environment.NewLine + "/ra " +Priest2.Text + " Gruppe 2" + Environment.NewLine + "/ra " +Priest3.Text + " Gruppe 3+4";
                        Clipboard.SetText(BuffString3);
                        break;
                    case 4:
                        string BuffString4 = "/ra " + Priest1.Text + " Gruppe 1" + Environment.NewLine + "/ra " +Priest2.Text + " Gruppe 2" + Environment.NewLine + "/ra " +Priest3.Text + " Gruppe 3" + Environment.NewLine + "/ra " +Priest4.Text + " Gruppe 4";
                        Clipboard.SetText(BuffString4);
                        break;


                }
            }
            if (_40er.IsChecked == true)
            {

                switch (FillList('P', 40))
                {
                    case 1:
                        string BuffString1 = "/ra " + Priest1.Text + " Gruppe 1-8";
                        Clipboard.SetText(BuffString1);
                        break;
                    case 2:
                        string BuffString2 = "/ra " + Priest1.Text + " Gruppe 1,3,5,7" + Environment.NewLine + "/ra " +Priest2.Text + " Gruppe 2,4,6,8";
                        Clipboard.SetText(BuffString2);
                        break;
                    case 3:
                        string BuffString3 = "/ra " + Priest1.Text + " Gruppe 1,3" + Environment.NewLine + "/ra " +Priest2.Text + " Gruppe 2,4 " + Environment.NewLine + "/ra " +Priest3.Text + " Gruppe 5-8";
                        Clipboard.SetText(BuffString3);
                        break;
                    case 4:
                        string BuffString4 = "/ra " + Priest1.Text + " Gruppe 1,3" + Environment.NewLine + "/ra " +Priest2.Text + " Gruppe 2,4" + Environment.NewLine + "/ra " +Priest3.Text + " Gruppe 5-6" + Environment.NewLine + "/ra " +Priest4.Text + " Gruppe 7-8";
                        Clipboard.SetText(BuffString4);
                        break;
                    case 5:
                        string BuffString5 = "/ra " + Priest1.Text + " Gruppe 1" + Environment.NewLine + "/ra " +Priest2.Text + " Gruppe 2" + Environment.NewLine + "/ra " +Priest3.Text + " Gruppe 3-4" + Environment.NewLine + "/ra " +Priest4.Text + " Gruppe 5-6" + Environment.NewLine + "/ra " +Priest5.Text + " Gruppe 7-8";
                        Clipboard.SetText(BuffString5);
                        break;
                    case 6:
                        string BuffString6 = "/ra " + Priest1.Text + " Gruppe 1" + Environment.NewLine + "/ra " +Priest2.Text + " Gruppe 2" + Environment.NewLine + "/ra " +Priest3.Text + " Gruppe 3" + Environment.NewLine + "/ra " +Priest4.Text + " Gruppe 4-5" + Environment.NewLine + "/ra " +Priest5.Text + " Gruppe 6-7" + Environment.NewLine + "/ra " +Priest6.Text + " Gruppe 8";
                        Clipboard.SetText(BuffString6);
                        break;
                    case 7:
                        string BuffString7 = "/ra " + Priest1.Text + " Gruppe 1" + Environment.NewLine + "/ra " +Priest2.Text + " Gruppe 2" + Environment.NewLine + "/ra " +Priest3.Text + " Gruppe 3" + Environment.NewLine + "/ra " +Priest4.Text + " Gruppe 4" + Environment.NewLine + "/ra " +Priest5.Text + " Gruppe 5" + Environment.NewLine + "/ra " +Priest6.Text + " Gruppe 6-7" + Environment.NewLine + "/ra " +Priest7.Text + " Gruppe 8";
                        Clipboard.SetText(BuffString7);
                        break;


                }
            }
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
            if(c == 'D' && raidSize == 40)
            {

                if (Druid1.Text != "")
                    returnval++;
                if (Druid2.Text != "")
                    returnval++;
                if (Druid3.Text != "")
                    returnval++;
                if (Druid4.Text != "")
                    returnval++;

                if (Druid5.Text != "")
                    returnval++;
                if (Druid6.Text != "")
                    returnval++;
                if (Druid7.Text != "")
                    returnval++;
            }
            if (c == 'M' && raidSize == 20)
            {
                if (Mage1.Text != "")
                    returnval++;
                if (Mage2.Text != "")
                    returnval++;
                if (Mage3.Text != "")
                    returnval++;
                if (Mage4.Text != "")
                    returnval++;

            }
            if (c == 'M' && raidSize == 40)
            {

                if (Mage1.Text != "")
                    returnval++;
                if (Mage2.Text != "")
                    returnval++;
                if (Mage3.Text != "")
                    returnval++;
                if (Mage4.Text != "")
                    returnval++;

                if (Mage5.Text != "")
                    returnval++;
                if (Mage6.Text != "")
                    returnval++;
                if (Mage7.Text != "")
                    returnval++;
            }
            if (c == 'P' && raidSize == 20)
            {
                if (Priest1.Text != "")
                    returnval++;
                if (Priest2.Text != "")
                    returnval++;
                if (Priest3.Text != "")
                    returnval++;
                if (Priest4.Text != "")
                    returnval++;

            }
            if (c == 'P' && raidSize == 40)
            {

                if (Priest1.Text != "")
                    returnval++;
                if (Priest2.Text != "")
                    returnval++;
                if (Priest3.Text != "")
                    returnval++;
                if (Priest4.Text != "")
                    returnval++;

                if (Priest5.Text != "")
                    returnval++;
                if (Priest6.Text != "")
                    returnval++;
                if (Priest7.Text != "")
                    returnval++;
            }
            StatusBar.Content = returnval + " Spieler wurden eingeteilt!";
            return returnval;

        }

        private void _20er_Checked(object sender, RoutedEventArgs e)
        {
            if (_40er.IsChecked == true)
                _40er.IsChecked = false;
        }

        private void _40er_Checked(object sender, RoutedEventArgs e)
        {
            if (_20er.IsChecked == true)
                _20er.IsChecked = false;
        }

        private void Speichern_Click(object sender, RoutedEventArgs e)
        {
            if (path == "")
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                if (saveFileDialog.ShowDialog().Value)
                    path = saveFileDialog.FileName;
                else
                {
                    MessageBox.Show("Bitte eine Datei auswählen", "Fehler");
                    return;
                }

            }

            StreamWriter writer = new StreamWriter(path);

            writer.WriteLine(Druid1.Text);
            writer.WriteLine(Druid2.Text);
            writer.WriteLine(Druid3.Text);
            writer.WriteLine(Druid4.Text);
            writer.WriteLine(Druid5.Text); 
            writer.WriteLine(Druid6.Text);
            writer.WriteLine(Druid7.Text);


            writer.WriteLine("Gruppe beendet");

            writer.WriteLine(Mage1.Text);
            writer.WriteLine(Mage2.Text);
            writer.WriteLine(Mage3.Text);
            writer.WriteLine(Mage4.Text);
            writer.WriteLine(Mage5.Text);
            writer.WriteLine(Mage6.Text);
            writer.WriteLine(Mage7.Text);

            writer.WriteLine("Gruppe beendet");

            writer.WriteLine(Priest1.Text);
            writer.WriteLine(Priest2.Text);
            writer.WriteLine(Priest3.Text);
            writer.WriteLine(Priest4.Text);
            writer.WriteLine(Priest5.Text);
            writer.WriteLine(Priest6.Text);
            writer.WriteLine(Priest7.Text);

            writer.WriteLine("Gruppe beendet");

            writer.Close();

        }

        private void Öffnen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog().Value)
            {
                StreamReader reader = new StreamReader(openFileDialog.OpenFile());

                Druid1.Text = reader.ReadLine();
                Druid2.Text = reader.ReadLine();
                Druid3.Text = reader.ReadLine();
                Druid4.Text = reader.ReadLine();
                Druid5.Text = reader.ReadLine();
                Druid6.Text = reader.ReadLine();
                Druid7.Text = reader.ReadLine();

                reader.ReadLine();

                Mage1.Text = reader.ReadLine();
                Mage2.Text = reader.ReadLine();
                Mage3.Text = reader.ReadLine();
                Mage4.Text = reader.ReadLine();
                Mage5.Text = reader.ReadLine();
                Mage6.Text = reader.ReadLine();
                Mage7.Text = reader.ReadLine();

                reader.ReadLine();

                Priest1.Text = reader.ReadLine();
                Priest2.Text = reader.ReadLine();
                Priest3.Text = reader.ReadLine();
                Priest4.Text = reader.ReadLine();
                Priest5.Text = reader.ReadLine();
                Priest6.Text = reader.ReadLine();
                Priest7.Text = reader.ReadLine();



            }

        }
    }
    
}
