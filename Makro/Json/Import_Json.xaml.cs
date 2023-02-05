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
    /// Interaktionslogik für Import_Json.xaml
    /// </summary>
    public partial class Import_Json : Window
    {
        public string Json { get; set; }

        public Import_Json()
        {
            InitializeComponent();
        }

        private void Button_Importieren_Click(object sender, RoutedEventArgs e)
        {
            Json = InputBox.Text;
            Close();
        }

        private void Button_Abbrechen_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Bist du sicher?", "Warnung") == MessageBoxResult.OK)
                Close();
        }
    }
}
