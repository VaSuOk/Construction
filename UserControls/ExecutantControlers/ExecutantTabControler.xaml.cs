using Construction.Auxiliary_classes;
using Construction.Context;
using Construction.HttpRequests;
using Construction.Model;
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
using Сonstruction.Auxiliary_classes;
using Сonstruction.Model;

namespace Construction.UserControls.ExecutantControlers
{
    /// <summary>
    /// Логика взаимодействия для ExecutantTabControler.xaml
    /// </summary>
    public partial class ExecutantTabControler : UserControl
    {
        private ListUserWI userWI;
        private Regions Regions;
        private List<StageAndPosition> stageAndPositions = StageAndPosition.GetCategories();

        public ExecutantTabControler()
        {
            
            InitializeComponent();
            GridCreateExecutant.Children.Add(new CreateExecutantControl());
            userWI = new ListUserWI();
            ListView.ItemsSource = userWI.userWorkInformation;
            Regions = new Regions();
            WRegion.ItemsSource = Regions.regions;
            Stage.ItemsSource = stageAndPositions;
            Stage.SelectionChanged += (s, e) =>
            {
                Position.ItemsSource = ((StageAndPosition)Stage.SelectedItem).Position;
                Position.ToolTip = null;
            };
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

        private void Border_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            var border = (FrameworkElement)sender;
            var text = (UserWorkInformation)border.DataContext;
            if (text.ID > 0)
            {
                ExecutantInfo.Visibility = Visibility.Visible;    
                GridInfoExecutant.Children.Add(new ExecutantInfoControl(text));
                Executant.SelectedIndex++;
            }
        }

        private void BFilter_Click(object sender, RoutedEventArgs e)
        {
            userWI.userWorkInformation = UserWorkInformationRequest.GetUserByStageAndPosition(WRegion.Text, Stage.Text, Position.Text);
            ListView.ItemsSource = userWI.userWorkInformation;
        }

        private void Border_MouseEnter(object sender, MouseEventArgs e)
        {
            var border = (Border)sender;
            border.Background = Brushes.Gray;
        }

        private void Border_MouseLeave(object sender, MouseEventArgs e)
        {
            var border = (Border)sender;
            var bc = new BrushConverter();
            border.Background = (Brush)bc.ConvertFrom("#FF1D1F20");
        }
    }
}
