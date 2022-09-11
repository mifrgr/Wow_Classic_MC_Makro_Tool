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


namespace Makro
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void _20er_Click(object sender, RoutedEventArgs e)
        {
            Buffs raid = new Buffs();
            raid.Show();

        }

        private void MC_Click_1(object sender, RoutedEventArgs e)
        {
            MC raid = new MC();
            raid.Show();
        }
    }
}
