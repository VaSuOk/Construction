using Construction.Auxiliary_classes;
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

namespace Construction.UserControls.BrigadeControlers
{
    /// <summary>
    /// Логика взаимодействия для BrigadeListControl.xaml
    /// </summary>
    public partial class BrigadeListControl : UserControl
    {
        public List<ViewBrigade> viewBrigades { get; set; }
        private Regions regions;
        private Stage stage;
        private WorkStatus workStatus;
        private TabItem tabItem1;

        public BrigadeListControl(ref TabItem tabItem)
        {
            InitializeComponent();
            InitList();
            tabItem1 = tabItem;
            regions = new Regions();
            stage = new Stage();
            workStatus = new WorkStatus();
            WStatus.ItemsSource = workStatus.status;
            Stage.ItemsSource = stage.stage;
            WRegion.ItemsSource = regions.regions;
        }
        private void InitList()
        {
            viewBrigades = new List<ViewBrigade>();
            List<Brigade> brigades = BrigadeRequest.GetBrigade(WRegion.Text, Stage.Text, WorkStatus.GetBoolStatus(WStatus.Text));
            if (brigades != null)
            {
                foreach (var item in brigades)
                {
                    viewBrigades.Add(new ViewBrigade(item));
                }
            }
            ListView.ItemsSource = viewBrigades;
        }
        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenSearch.Visibility = Visibility.Visible;
            ButtonCloseSearch.Visibility = Visibility.Collapsed;
            RFilter.Visibility = Visibility.Visible;
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
            ButtonRefresh.Visibility = Visibility.Collapsed;
            ButtonOpenSearch.Visibility = Visibility.Collapsed;

            RSearch.Visibility = Visibility.Collapsed;
        }
        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
            ButtonRefresh.Visibility = Visibility.Visible;
            ButtonOpenSearch.Visibility = Visibility.Visible;
        }

        private void Border_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            var border = (FrameworkElement)sender;
            var text = (ViewBrigade)border.DataContext;
            if (text.brigade.ID > 0)
            {
                tabItem1.Content = new SeletedBrigadeInfoControl(text);
                tabItem1.Visibility = Visibility.Visible;
            }
        }

        private void BFilter_Click(object sender, RoutedEventArgs e)
        {
            InitList();
        }

        private void BSelected_MouseEnter(object sender, MouseEventArgs e)
        {
            var border = (Border)sender;
            border.Background = Brushes.Gray;
        }

        private void BSelected_MouseLeave(object sender, MouseEventArgs e)
        {
            var border = (Border)sender;
            var bc = new BrushConverter();
            border.Background =(Brush)bc.ConvertFrom("#FF1D1F20");
        }

        private void ButtonRefresh_Click(object sender, RoutedEventArgs e)
        {
            viewBrigades = new List<ViewBrigade>();
            List<Brigade> brigades = BrigadeRequest.GetBrigade("none", "none", false);
            if (brigades != null)
            {
                foreach (var item in brigades)
                {
                    viewBrigades.Add(new ViewBrigade(item));
                }
            }
            ListView.ItemsSource = viewBrigades;
        }

        private void ButtonCloseSearch_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenSearch.Visibility = Visibility.Visible;
            ButtonCloseSearch.Visibility = Visibility.Collapsed;
        }

        private void ButtonOpenSearch_Click(object sender, RoutedEventArgs e)
        {
            RFilter.Visibility = Visibility.Collapsed;
            RSearch.Visibility = Visibility.Visible;
            ButtonOpenSearch.Visibility = Visibility.Collapsed;
            ButtonCloseSearch.Visibility = Visibility.Visible;
        }

        private void BSearch_Click(object sender, RoutedEventArgs e)
        {
            viewBrigades = new List<ViewBrigade>();
            List<Brigade> brigades = BrigadeRequest.GetBrigadeByName(SearchName.Text);
            if (brigades != null)
            {
                foreach (var item in brigades)
                {
                    viewBrigades.Add(new ViewBrigade(item));
                }
            }
            ListView.ItemsSource = viewBrigades;
        }
    }
}
