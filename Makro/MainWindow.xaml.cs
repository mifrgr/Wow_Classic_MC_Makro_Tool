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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Microsoft.Win32;
using System.Diagnostics;

namespace Makro
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string MacroTextGarr;
        string MacroTextSulfuron;
        string MacroTextMajordomus;
        string MacroTextHunde;

        List<TextBox> TanksList = new List<TextBox>();
        List<TextBox> MageList = new List<TextBox>();
        List<TextBox> RougeList = new List<TextBox>();
        List<TextBox> WarlockList = new List<TextBox>();

        List<bool> Symbols;

        string path ="";

        /*
         * Stern = rt1
         * Kreis = rt2
         * Kristall = rt3
         * Dreieck = rt4
         * Mond = rt5
         * Quadrat = rt6
         * Kreuz = rt7
         * Totenkopf = rt8
         */
        enum Symbol { rt8 = 1, rt7 =2, rt4=3, rt6=4, rt5=5, rt1=6, rt3=7, rt2=8}

        public MainWindow()
        {
            InitializeComponent();

        }

        private void FillLists()
        {
            if (TanksList.Count > 0)
                TanksList.Clear();

            TanksList.Add(Tank1);
            TanksList.Add(Tank2);
            TanksList.Add(Tank3);
            TanksList.Add(Tank4);
            TanksList.Add(Tank5);
            TanksList.Add(Tank6);
            TanksList.Add(Tank7);

            if (MageList.Count > 0)
                MageList.Clear();

            MageList.Add(Mage1);
            MageList.Add(Mage2);
            MageList.Add(Mage3);
            MageList.Add(Mage4);
            MageList.Add(Mage5);
            MageList.Add(Mage6);
            MageList.Add(Mage7);

            if (RougeList.Count > 0)
                RougeList.Clear();

            RougeList.Add(Roug1);
            RougeList.Add(Roug2);
            RougeList.Add(Roug3);
            RougeList.Add(Roug4);
            RougeList.Add(Roug5);
            RougeList.Add(Roug6);
            RougeList.Add(Roug7);

            if (WarlockList.Count > 0)
                WarlockList.Clear();

            WarlockList.Add(Warl1);
            WarlockList.Add(Warl2);
            WarlockList.Add(Warl3);
            WarlockList.Add(Warl4);
            WarlockList.Add(Warl5);
            WarlockList.Add(Warl6);
            WarlockList.Add(Warl7);

        }

        private void ResetTanks_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("Willst du wirklich alles zurücksetzen","Achtung",MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Tank1.Text = "";
                Tank2.Text = "";
                Tank3.Text = "";
                Tank4.Text = "";
                Tank5.Text = "";
                Tank6.Text = "";
                Tank7.Text = "";
            }


        }

        private void ResetMage_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Willst du wirklich alles zurücksetzen", "Achtung", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Mage1.Text = "";
                Mage2.Text = "";
                Mage3.Text = "";
                Mage4.Text = "";
                Mage5.Text = "";
                Mage6.Text = "";
                Mage7.Text = "";
            }
        }

        private void ResetRog_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Willst du wirklich alles zurücksetzen", "Achtung", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Roug1.Text = "";
                Roug2.Text = "";
                Roug3.Text = "";
                Roug4.Text = "";
                Roug5.Text = "";
                Roug6.Text = "";
                Roug7.Text = "";
            }
        }

        private void ResetWL_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Willst du wirklich alles zurücksetzen", "Achtung", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Warl1.Text = "";
                Warl2.Text = "";
                Warl3.Text = "";
                Warl4.Text = "";
                Warl5.Text = "";
                Warl6.Text = "";
                Warl7.Text = "";
            }
        }

        private void Button_Garr_Auswerten_Click(object sender, RoutedEventArgs e)
        {
            FillLists();
            Garr();
        }

        private void Garr()
        {
            Symbols = new List<bool>() { false, false, false, false, false, false, false, false };

            MacroTextGarr = "/ra Garr = " + Tank1.Text + Environment.NewLine;
            for (int i = 0; i < 7; i++)
            {
                if(WarlockList[i].Text != "")
                {
                    for(int j = 7; j > 0;j--)
                    {
                        if( Symbols[j] == false)
                        {
                            MacroTextGarr += "/ra {" + ((Symbol)j + 1).ToString();
                            Symbols[j] = true;
                            MacroTextGarr += "} = " + WarlockList[i].Text + Environment.NewLine;
                            break;
                        }
                    }

                } 

            }

            for(int i = 1; i < 7;i++)
            {
                if(TanksList[i].Text != "")
                {
                    for (int j = 0; j <= 7; j++)
                    {
                        if (Symbols[j] == false)
                        {
                            MacroTextGarr += "/ra {" + ((Symbol)j+1).ToString();
                            Symbols[j] = true;
                            MacroTextGarr += "} = " + TanksList[i].Text + Environment.NewLine;
                            break;
                        }
                    }

                }
            }

            byte actualMarks = 0;

            foreach (bool symbol in Symbols)
            {
                
                if (symbol)
                    actualMarks++;

            }
            if(actualMarks == 8)
                Statusleiste.Content = "Makro für Garr erfolgreich erstellt.";
            else
                Statusleiste.Content = "Nur " + actualMarks + " von 8 Tanks/Hexen!";

            Clipboard.SetText(MacroTextGarr);
        }
        private async Task SulfuronHerold()
        {
            Symbols = new List<bool>() { false, false, false, false, false, false, false, false };

            MacroTextSulfuron = "/ra Sulfuronherold = " + Tank1.Text + Environment.NewLine;
            MacroTextSulfuron += "/ra {rt8} Tank = " + Tank2.Text + Environment.NewLine;
            MacroTextSulfuron += "/ra {rt7} Tank = " + Tank3.Text + Environment.NewLine;
            MacroTextSulfuron += "/ra {rt4} Tank = " + Tank4.Text + Environment.NewLine;
            MacroTextSulfuron += "/ra {rt6} Tank = " + Tank5.Text + Environment.NewLine;


            for (int i = 0; i < 7; i++)
            {
                if (RougeList[i].Text != "")
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (Symbols[j] == false)
                        {
                            MacroTextSulfuron += "/ra {" + ((Symbol)j + 1).ToString() + "} Kick";
                            Symbols[j] = true;
                            MacroTextSulfuron += " = " + RougeList[i].Text + Environment.NewLine;
                            break;
                        }
                    }

                }

            }

            byte actualMarks = 0;

            foreach (bool symbol in Symbols)
            {

                if (symbol)
                    actualMarks++;

            }
            if (actualMarks == 4)
                Statusleiste.Content = "Makro für Garr erfolgreich erstellt.";
            else
                Statusleiste.Content = "Nur " + actualMarks + " von 4 Kicker!";
            Clipboard.SetText(MacroTextSulfuron);
        }

        private void Majordomus()
        {
            Symbols = new List<bool>() { false, false, false, false, false, false, false, false };


            MacroTextMajordomus = "/ra Majordomus = " + Tank1.Text + Environment.NewLine;
            MacroTextMajordomus += "/ra {rt8} Tank = " + Tank2.Text + Environment.NewLine;
            MacroTextMajordomus += "/ra {rt7} Tank = " + Tank3.Text + Environment.NewLine;
            MacroTextMajordomus += "/ra {rt4} Tank = " + Tank4.Text + Environment.NewLine;
            MacroTextMajordomus += "/ra {rt6} Tank = " + Tank5.Text + Environment.NewLine;

            for (int i = 0; i < 7; i++)
            {
                if (MageList[i].Text != "")
                {
                    for (int j = 4; j <= 7; j++)
                    {
                        if (Symbols[j] == false)
                        {
                            MacroTextMajordomus += "/ra {" + ((Symbol)j + 1).ToString() + "} Sheep/Tank";
                            Symbols[j] = true;
                            MacroTextMajordomus += " = " + MageList[i].Text + Environment.NewLine;
                            break;
                        }
                    }

                }

            }

            if(Symbols[3])
                Symbols = new List<bool>() { false, false, false, false, false, false, false, false };

            for (int i = 5; i < 7; i++)
            {
                if (TanksList[i].Text != "")
                {
                    for (int j = 4; j <= 7; j++)
                    {
                        if (Symbols[j] == false)
                        {
                            MacroTextMajordomus += "/ra {" + ((Symbol)j + 1).ToString() + "} Sheep/Tank";
                            Symbols[j] = true;
                            MacroTextMajordomus += " = " + TanksList[i].Text + Environment.NewLine;
                            break;
                        }
                    }

                }
            }

            byte actualMarks = 4;

            foreach (bool symbol in Symbols)
            {

                if (symbol)
                    actualMarks++;

            }
            if (actualMarks == 8)
                Statusleiste.Content = "Makro für Majordomus erfolgreich erstellt.";
            else
                Statusleiste.Content = "Nur " + actualMarks + " von 8 Tanks/Mages!";

            Clipboard.SetText(MacroTextGarr);
            Clipboard.SetText(MacroTextMajordomus);
        }
        private void Hunde ()
        {
            if(Tank1.Text != "" & Tank2.Text != "" & Tank3.Text != "" & Tank4.Text != "" & Tank5.Text != "" )
            {
                MacroTextHunde = "/ra {rt8} = " + Tank1.Text + Environment.NewLine;
                MacroTextHunde += "/ra {rt7} = " + Tank2.Text + Environment.NewLine;
                MacroTextHunde += "/ra {rt4} = " + Tank3.Text + Environment.NewLine;
                MacroTextHunde += "/ra {rt6} = " + Tank4.Text + Environment.NewLine;
                MacroTextHunde += "/ra {rt5} = " + Tank5.Text + Environment.NewLine;

                Statusleiste.Content = "Makro für Hunde-Einteilung erfolgreich erstellt!";
                Clipboard.SetText(MacroTextHunde);
            }
            else
                Statusleiste.Content = "Fehler bei der Makro-Erstellung!";


        }
        private void Button_Sulf_Auswerten_Click(object sender, RoutedEventArgs e)
        {
            FillLists();
            SulfuronHerold();
        }

        private void Button_Major_Auswerten_Click(object sender, RoutedEventArgs e)
        {
            FillLists();
            Majordomus();
        }

        private void Button_Hunde_Auswerten_Click(object sender, RoutedEventArgs e)
        {
            FillLists();
            Hunde();

        }

        private void Button_Speichern_Click(object sender, RoutedEventArgs e)
        {
            FillLists();

            if(path =="")
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

            foreach (TextBox entry in TanksList)
            {
                if (entry.Text != "")
                    writer.WriteLine(entry.Text);
            }

            writer.WriteLine("Gruppe beendet");

            foreach (TextBox entry2 in MageList)
            {
                    if (entry2.Text != "")
                        writer.WriteLine(entry2.Text);
            }

            writer.WriteLine("Gruppe beendet");

            foreach (TextBox entry3 in RougeList)
            {
                    if (entry3.Text != "")
                        writer.WriteLine(entry3.Text);
            }

            writer.WriteLine("Gruppe beendet");

            foreach (TextBox entry4 in WarlockList)
            {
                    if (entry4.Text != "")
                        writer.WriteLine(entry4.Text);
            }

            writer.WriteLine("Gruppe beendet");

            writer.Close();


            }

        private void Button_Öffnen_Click(object sender, RoutedEventArgs e)
        {
            FillLists();
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if(openFileDialog.ShowDialog().Value)
            {
                StreamReader reader = new StreamReader(openFileDialog.OpenFile());

                string actualLine;

                int actualList = 0;



                while ((actualLine = reader.ReadLine()) != null)
                {

                    if (actualLine == "Gruppe beendet")
                    {
                        actualList++;
                    }

                   

                    foreach (TextBox entry in TanksList)
                    {                        
                        if(actualList == 0 && entry.Text == "" && actualLine != "Gruppe beendet")
                        {
                            entry.Text = actualLine;
                            break;
                        }
                        if (actualLine == "Gruppe beendet" && actualList == 1)
                            break;

                            
                    }

                    foreach (TextBox entry in MageList)
                    {
                        if(actualList == 1 && entry.Text == "" && actualLine != "Gruppe beendet")
                        {
                            entry.Text = actualLine;
                            break;
                        }
                        if (actualLine == "Gruppe beendet" && actualList == 2)
                            break;

                    }

                    foreach (TextBox entry in RougeList)
                    {
                        if(actualList == 2 && entry.Text == "" && actualLine != "Gruppe beendet")
                        {
                            entry.Text = actualLine;
                            break;
                        }
                        if (actualLine == "Gruppe beendet" && actualList == 3)
                            break;

                    }

                    foreach (TextBox entry in WarlockList)
                    {
                        if(actualList == 3 && entry.Text == "" && actualLine != "Gruppe beendet")
                        {
                            entry.Text = actualLine;
                            break;
                        }
                        if (actualLine == "Gruppe beendet" && actualList == 4)
                            break;
                    }

                }

            }
            
        }
    }
}
