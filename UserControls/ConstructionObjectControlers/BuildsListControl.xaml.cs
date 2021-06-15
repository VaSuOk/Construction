using Construction.Auxiliary_classes;
using Construction.HttpRequests;
using Construction.Model;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Construction.UserControls.ConstructionObjectControlers
{

   
    public partial class BuildsListControl : UserControl
    { 
        private List<ConstructionObject> buildObject;
        private Regions ORegions;
        private TypeBuild typeBuild;
        private TabItem tabItem1;
        public BuildsListControl(ref TabItem tabItem)
        {
            InitializeComponent();
            buildObject = ConstructionRequest.GetALLConstO(WRegion.Text, TSity.Text, CType.Text);
            InitDataList();
            tabItem1 = tabItem;
            ORegions = new Regions();
            typeBuild = new TypeBuild();
            WRegion.ItemsSource = ORegions.regions;
            CType.ItemsSource = typeBuild.type;
        }
        private void InitDataList()
        {
            if(buildObject != null)
            {
                foreach (var item in buildObject)
                {
                    if(item.Image.Length < 20)
                    {
                        var imageSource = new BitmapImage();
                        FileStream fs = null;
                        switch (item.TypeBuilding)
                        {
                            case "Приватний будинок":
                                {
                                    fs = new FileStream(@"D:\KPK\ДИПЛОМ\SOFT\Construction\Source\Private.png", FileMode.Open, FileAccess.Read);
                                    break;
                                }
                            case "Квартирний будинок":
                                {
                                    fs = new FileStream(@"D:\KPK\ДИПЛОМ\SOFT\Construction\Source\квартика.png", FileMode.Open, FileAccess.Read);
                                    break;
                                }
                            case "Офісний будинок":
                                {
                                    fs = new FileStream(@"D:\KPK\ДИПЛОМ\SOFT\Construction\Source\oficc.png", FileMode.Open, FileAccess.Read);
                                    break;
                                }
                            case "Виробничий будинок":
                                {
                                    fs = new FileStream(@"D:\KPK\ДИПЛОМ\SOFT\Construction\Source\заводФ.png", FileMode.Open, FileAccess.Read);
                                    break;
                                }
                            case "Оздоровчий будинок":
                                {
                                    fs = new FileStream(@"D:\KPK\ДИПЛОМ\SOFT\Construction\Source\freedom.png", FileMode.Open, FileAccess.Read);
                                    break;
                                }
                        }
                        byte[] bStream = new byte[fs.Length];
                        fs.Read(bStream, 0, Convert.ToInt32(fs.Length));
                        fs.Close();
                        item.Image = bStream;
                    }
                }
                
            }
            ListView.ItemsSource = buildObject;
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

        private void BFilter_Click(object sender, RoutedEventArgs e)
        {
            buildObject = ConstructionRequest.GetALLConstO(WRegion.Text, TSity.Text, CType.Text);
            InitDataList();
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
        private void Border_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            var border = (FrameworkElement)sender;
            var text = (ConstructionObject)border.DataContext;
            if (text.ID > 0)
            {
                tabItem1.Content = new SelectedConstuctionOControl(text);
                tabItem1.Visibility = Visibility.Visible;
            }
        }

        private void ButtonOpenSearch_Click(object sender, RoutedEventArgs e)
        {
            RFilter.Visibility = Visibility.Collapsed;
            RSearch.Visibility = Visibility.Visible;
            ButtonOpenSearch.Visibility = Visibility.Collapsed;
            ButtonCloseSearch.Visibility = Visibility.Visible;
        }

        private void ButtonCloseSearch_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenSearch.Visibility = Visibility.Visible;
            ButtonCloseSearch.Visibility = Visibility.Collapsed;
        }

        private void ButtonRefresh_Click(object sender, RoutedEventArgs e)
        {
            buildObject = ConstructionRequest.GetALLConstO("none", "none", "none");
            InitDataList();
        }

        private void BSearch_Click(object sender, RoutedEventArgs e)
        {
            buildObject = ConstructionRequest.GetConstructionOBySearch(SearchName.Text, SearchStreet.Text);
            InitDataList();
        }
    }
}
