using Construction.HttpRequests;
using Construction.UserControls.BrigadeControlers;
using Construction.UserControls.ConstructionObjectControlers;
using Construction.UserControls.ExecutantControlers;
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
            /*
            if(AdminRequest.AdminLogin(TextLogin.Text, TextPassword.Text) == 1)
            {
                GridBlur.Visibility = Visibility.Collapsed;
                GridLogin.Visibility = Visibility.Collapsed;
            }
            else
            {
                TextLogin.BorderBrush = Brushes.Red;
                TextPassword.BorderBrush = Brushes.Red;
            }*/
            GridBlur.Visibility = Visibility.Collapsed;
            GridLogin.Visibility = Visibility.Collapsed;
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UserControl usc = null;
            
            GridMain.Children.Clear();

            switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            {
                case "Executant":
                    usc = new ExecutantTabControler();
                    GridMain.Children.Add(usc);
                    break;
                case "Brigade":
                    usc = new BrigadeTabControl();
                    GridMain.Children.Add(usc);
                    break;
                case "Construction":
                    usc = new ConstructionTabControler();
                    GridMain.Children.Add(usc);
                    break;
                default:
                    break;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
