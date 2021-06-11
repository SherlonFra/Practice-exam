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

namespace Practice_exam
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void mnuAbout_Click(object sender, RoutedEventArgs e)
        {
            About win2 = new About();
            win2.ShowDialog();
        }

        private void mnuNewStudent_Click(object sender, RoutedEventArgs e)
        {
            New_Student win2 = new New_Student();
            win2.ShowDialog();
        }

        private void mnuSearchStudent_Click(object sender, RoutedEventArgs e)
        {
            Search_Students win2 = new Search_Students();
            win2.ShowDialog();
        }

        private void mnuExportStudent_Click(object sender, RoutedEventArgs e)
        {
            Export_Students win2 = new Export_Students();
            win2.ShowDialog();
        }
    }
}
