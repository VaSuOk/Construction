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

namespace Construction
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
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            //login
            GridBlur.Visibility = Visibility.Collapsed;
            GridLogin.Visibility = Visibility.Collapsed;
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
