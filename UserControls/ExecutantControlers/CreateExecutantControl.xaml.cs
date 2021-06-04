using Construction.Auxiliary_classes;
using Construction.HttpRequests;
using Construction.Model;
using Microsoft.Win32;
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
using Сonstruction.Model;

namespace Construction.UserControls.ExecutantControlers
{
    /// <summary>
    /// Логика взаимодействия для CreateExecutantControl.xaml
    /// </summary>
    public partial class CreateExecutantControl : UserControl
    {
        private UserWorkInformation userWorkInformation;
        private string imageName, strName;
        private Regions LRegions;
        private Regions WRegions;
        private List<StageAndPosition> stageAndPositions = StageAndPosition.GetCategories();
        

        public CreateExecutantControl()
        {
            InitializeComponent();

            LRegions = new Regions();
            WRegions = new Regions();
            userWorkInformation = new UserWorkInformation();
            LRegion.ItemsSource = LRegions.regions;
            WRegions.AddRegionTypeAll();
            WRegion.ItemsSource = WRegions.regions;

            Stage.ItemsSource = stageAndPositions;
            Stage.SelectionChanged += (s, e) =>
            {
                Position.ItemsSource = ((StageAndPosition)Stage.SelectedItem).Position;
                Position.ToolTip = null;
            };
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (CheakInputData())
            {
                InitUser();
                LogBar.Foreground = Brushes.Green;
                LogBar.Visibility = Visibility.Visible;
                LogBar.Content = "Успішно зареєстровано!";
                UserWorkInformationRequest.CreateUserWorkInformation(userWorkInformation);
            }
        }
        public bool CheakInputData()
        {
            LogBar.Foreground = Brushes.Red;
            LogBar.Visibility = Visibility.Visible; //щоб не дублювати 100 раз
            if (string.IsNullOrWhiteSpace(TextName.Text))
            { LogBar.Content = "Введіть ім'я!"; /*TextName.BorderBrush = Brushes.Red;*/ }
            else if (string.IsNullOrWhiteSpace(TextSurname.Text))
            { LogBar.Content = "Введіть прізвище!";/* TextSurname.BorderBrush = Brushes.Red; */ }
            else if (string.IsNullOrWhiteSpace(TextEmail.Text))
            { LogBar.Content = "Введіть електронну пошту!";/* TextEmail.BorderBrush = Brushes.Red; */ }
            else if (string.IsNullOrWhiteSpace(TextPhone.Text))
            { LogBar.Content = "Введіть номер телефону!"; /*TextPhone.BorderBrush = Brushes.Red; */ }
            else if (string.IsNullOrWhiteSpace(LRegion.Text))
            { LogBar.Content = "Оберіть регіон проживання!";/* LRegion.BorderBrush = Brushes.Red; */ }
            else if (string.IsNullOrWhiteSpace(TextSity.Text))
            { LogBar.Content = "Введіть місто!"; /*TextSity.BorderBrush = Brushes.Red; */ }
            else if (string.IsNullOrWhiteSpace(CBirthday.Text))
            { LogBar.Content = "Оберіть дату народження!"; /*CBirthday.BorderBrush = Brushes.Red; */ }
            else if (string.IsNullOrWhiteSpace(WRegion.Text))
            { LogBar.Content = "Оберіть регіон роботи!";/* WRegion.BorderBrush = Brushes.Red; */ }
            else if (string.IsNullOrWhiteSpace(Stage.Text))
            { LogBar.Content = "Оберіть етап роботи!"; /*Stage.BorderBrush = Brushes.Red; */ }
            else if (string.IsNullOrWhiteSpace(Position.Text))
            { LogBar.Content = "Оберіть посаду!"; /*Position.BorderBrush = Brushes.Red; */ }
            else if (string.IsNullOrWhiteSpace(imageName))
            { LogBar.Content = "Завантажте фотографію!"; }
            else
            { LogBar.Visibility = Visibility.Hidden; return true; }
            return false;
        }
        public void InitUser()
        {
            User user = new User(); 
            user.Name = TextName.Text; user.Surname = TextSurname.Text; user.Email = TextEmail.Text; user.Phone = TextPhone.Text;
            user.Region = LRegion.Text; user.Sity = TextSity.Text; user.Birthday = CBirthday.Text;
            if (imageName != null)
            {
                FileStream fs = new FileStream(imageName, FileMode.Open, FileAccess.Read);
                byte[] imgByteArr = new byte[fs.Length];
                fs.Read(imgByteArr, 0, Convert.ToInt32(fs.Length));
                fs.Close();

                user.UserImage = imgByteArr;
            }
            userWorkInformation.user = user; userWorkInformation.ID = 1;
            userWorkInformation.Position = Position.Text; userWorkInformation.Stage = Stage.Text;
            userWorkInformation.WorkRegion = WRegion.Text; userWorkInformation.Salary = TextSalary.Text;  
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FileDialog fldlg = new OpenFileDialog();
                fldlg.InitialDirectory = Environment.SpecialFolder.MyPictures.ToString();
                fldlg.Filter = "Image File (*.jpg;*.bmp;*.gif)|*.jpg;*.bmp;*.gif";
                fldlg.ShowDialog();
                {
                    strName = fldlg.SafeFileName;
                    imageName = fldlg.FileName;
                    ImageSourceConverter isc = new ImageSourceConverter();
                    ImageBrush imgbr = new ImageBrush();
                    imgbr.ImageSource = new BitmapImage(new Uri(imageName, UriKind.Absolute));
                    BImg.Background = imgbr;

                }
                fldlg = null;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
