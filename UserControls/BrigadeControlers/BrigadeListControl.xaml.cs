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

        public BrigadeListControl()
        {
            InitializeComponent();
            InitList();
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
            
        }

        private void BFilter_Click(object sender, RoutedEventArgs e)
        {
            InitList();
        }
    }
}
