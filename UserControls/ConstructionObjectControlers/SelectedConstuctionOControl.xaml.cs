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
    /// Логика взаимодействия для SelectedConstuctionOControl.xaml
    /// </summary>
    public partial class SelectedConstuctionOControl : UserControl
    {
        private ConstructionObject constructionObject;
        private Regions regions;

        private TypeBuild typeBuild;
        private TypeRoof typeRoof;
        private RoofMaterial roofMaterial;
        private WallMaterial wallMaterial;

        public SelectedConstuctionOControl(ConstructionObject constructionObject)
        {
            InitializeComponent();
            this.constructionObject = constructionObject;
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
            TextData.Text = constructionObject.DataCreate;

            SetSelectedData();
        }
        private void SetSelectedData()
        {
            if(constructionObject.customer != null)
            {
                TextPIB.Text = constructionObject.customer.PIB;
                TextPhone.Text = constructionObject.customer.Phone;
                TextEmail.Text = constructionObject.customer.Email;
            }
            WRegion.SelectedItem = constructionObject.Region;
            TextSity.Text = constructionObject.Sity;
            TextStreet.Text = constructionObject.Street;
            CObjectType.SelectedItem = constructionObject.TypeBuilding;
            CTypeRoof.SelectedItem = constructionObject.TypeRoof;
            CRoofMaterial.SelectedItem = constructionObject.RoofMaterial;
            CWallMaterial.SelectedItem = constructionObject.WallMaterial;
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (CheakInputText())
            {
                InitinputData();
                if (ConstructionRequest.UppdateConstructionO(constructionObject).Result)
                {
                    LogBar.Content = "Зміни успішно збережені!";
                    LogBar.Visibility = Visibility.Visible;
                }
                else
                {
                    LogBar.Content = "Відсутнє з'єднання з сервером!";
                    LogBar.Visibility = Visibility.Visible;
                }
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (ConstructionRequest.DeleteConstructionO(constructionObject.ID).Result)
            {
                LogBar.Content = "Дані були успішно видалені!";
                LogBar.Visibility = Visibility.Visible;
            }
            else
            {
                LogBar.Content = "Відсутнє з'єднання з сервером!";
                LogBar.Visibility = Visibility.Visible;
            }
        }

        private void InitinputData()
        {
            constructionObject.customer.PIB = TextPIB.Text;
            constructionObject.customer.Phone = TextPhone.Text;
            constructionObject.customer.Email = TextEmail.Text;
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
