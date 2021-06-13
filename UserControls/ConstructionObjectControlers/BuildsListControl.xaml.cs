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
        public BuildsListControl()
        {
            InitializeComponent();
            InitDataList();
            ORegions = new Regions();
            typeBuild = new TypeBuild();
            WRegion.ItemsSource = ORegions.regions;
            CType.ItemsSource = typeBuild.type;
        }
        private void InitDataList()
        {
            buildObject = ConstructionRequest.GetALLConstO(WRegion.Text, TSity.Text, CType.Text);
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
                                    fs = new FileStream(@"D:\KPK\ДИПЛОМ\SOFT\Сonstruction сompany\Source\User.png", FileMode.Open, FileAccess.Read);
                                    break;
                                }
                            case "Офісний будинок":
                                {
                                    fs = new FileStream(@"D:\KPK\ДИПЛОМ\SOFT\Сonstruction сompany\Source\User.png", FileMode.Open, FileAccess.Read);
                                    break;
                                }
                            case "Виробничий будинок":
                                {
                                    fs = new FileStream(@"D:\KPK\ДИПЛОМ\SOFT\Сonstruction сompany\Source\User.png", FileMode.Open, FileAccess.Read);
                                    break;
                                }
                            case "Оздоровчий будинок":
                                {
                                    fs = new FileStream(@"D:\KPK\ДИПЛОМ\SOFT\Сonstruction сompany\Source\User.png", FileMode.Open, FileAccess.Read);
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
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
        }
        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
        }

        private void BFilter_Click(object sender, RoutedEventArgs e)
        {
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
    }
}
