using Construction.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Construction.UserControls.ExecutantControlers
{
    /// <summary>
    /// Логика взаимодействия для ListExecutantControl.xaml
    /// </summary>
    public partial class ListExecutantControl : UserControl
    {
        private ListUserWI userWI;
        public ListExecutantControl()
        {
            InitializeComponent();
            userWI = new ListUserWI();
            ListView.ItemsSource = userWI.userWorkInformation;
        }
        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
        }
        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
        }

    }
}
