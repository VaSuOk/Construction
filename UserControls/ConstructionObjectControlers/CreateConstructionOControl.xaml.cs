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

namespace Construction.UserControls.ConstructionObjectControlers
{
    /// <summary>
    /// Логика взаимодействия для CreateConstructionOControl.xaml
    /// </summary>
    public partial class CreateConstructionOControl : UserControl
    {
        private ConstructionObject constructionObject;
        private Regions regions;

        private TypeBuild typeBuild;
        private TypeRoof typeRoof;
        private RoofMaterial roofMaterial;
        private WallMaterial wallMaterial;

        public CreateConstructionOControl()
        {
            InitializeComponent();

            constructionObject = new ConstructionObject();

            regions = new Regions();
            typeBuild = new TypeBuild();
            typeRoof = new TypeRoof();
            roofMaterial = new RoofMaterial();
            wallMaterial = new WallMaterial();

            WRegion.ItemsSource = regions.regions;
            CObjectType.ItemsSource = typeBuild.type;
            CTypeRoof.ItemsSource = typeRoof.type;
            CRoofMaterial.ItemsSource = roofMaterial.Material;
            CWallMaterial.ItemsSource = wallMaterial.Material;
            TextData.Text = DateTime.Now.ToString("G").Split(' ')[0];
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (CheakInputText()) 
            {
                InitinputData();
                ConstructionRequest.CreateUserWorkInformation(constructionObject);
            }
        }

        private void InitinputData()
        {
            Customer customer = new Customer();
            customer.PIB = TextPIB.Text;
            customer.Phone = TextPhone.Text;
            customer.Email = TextEmail.Text;
            constructionObject.customer = customer;
            constructionObject.Region = WRegion.Text;
            constructionObject.Sity = TextSity.Text;
            constructionObject.Street = TextStreet.Text;
            constructionObject.TypeBuilding = CObjectType.Text;
            constructionObject.TypeRoof = CTypeRoof.Text;
            constructionObject.RoofMaterial = CRoofMaterial.Text;
            constructionObject.WallMaterial = CWallMaterial.Text;
            constructionObject.DataCreate = TextData.Text;
        }
        private bool CheakInputText()
        {
            LogBar.Foreground = Brushes.Red;
            LogBar.Visibility = Visibility.Visible; //
            if (string.IsNullOrWhiteSpace(TextPIB.Text))
            { LogBar.Content = "Введіть ініціали замовника!"; /*TextName.BorderBrush = Brushes.Red;*/ }
            else if (string.IsNullOrWhiteSpace(TextPhone.Text))
            { LogBar.Content = "Введіть номер телефону!";/* TextSurname.BorderBrush = Brushes.Red; */ }
            else if (string.IsNullOrWhiteSpace(TextEmail.Text))
            { LogBar.Content = "Введіть електронну пошту!";/* TextEmail.BorderBrush = Brushes.Red; */ }
            else if (string.IsNullOrWhiteSpace(WRegion.Text))
            { LogBar.Content = "Оберіть регіон місця будівництва!";/* LRegion.BorderBrush = Brushes.Red; */ }
            else if (string.IsNullOrWhiteSpace(TextSity.Text))
            { LogBar.Content = "Введіть місто будівництва!"; /*TextSity.BorderBrush = Brushes.Red; */ }
            else if (string.IsNullOrWhiteSpace(TextStreet.Text))
            { LogBar.Content = "Оберіть вулицю будівництва!"; /*CBirthday.BorderBrush = Brushes.Red; */ }
            else if (string.IsNullOrWhiteSpace(CObjectType.Text))
            { LogBar.Content = "Оберіть тип будинку!";/* WRegion.BorderBrush = Brushes.Red; */ }
            else if (string.IsNullOrWhiteSpace(CTypeRoof.Text))
            { LogBar.Content = "Оберіть тип даху!"; /*Stage.BorderBrush = Brushes.Red; */ }
            else if (string.IsNullOrWhiteSpace(CRoofMaterial.Text))
            { LogBar.Content = "Оберіть матеріал покрівлі даху!"; /*Position.BorderBrush = Brushes.Red; */ }
            else if (string.IsNullOrWhiteSpace(CWallMaterial.Text))
            { LogBar.Content = "Оберіть матеріал стін!"; }
            else
            { LogBar.Visibility = Visibility.Hidden; return true; }
            return false;
        }
    }
}
