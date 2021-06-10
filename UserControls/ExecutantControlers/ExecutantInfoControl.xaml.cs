using Construction.Auxiliary_classes;
using Construction.HttpRequests;
using Construction.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Сonstruction.Auxiliary_classes;
using Сonstruction.Model;

namespace Construction.UserControls.ExecutantControlers
{
    /// <summary>
    /// Логика взаимодействия для ExecutantInfoControl.xaml
    /// </summary>
    public partial class ExecutantInfoControl : UserControl
    {
        private UserWorkInformation userWorkInformation;
        private string imageName, strName;
        private Regions LRegions;
        private Regions WRegions;
        private List<StageAndPosition> stageAndPositions = StageAndPosition.GetCategories();

        public ExecutantInfoControl(UserWorkInformation executant)
        {
            InitializeComponent();

            LRegions = new Regions();
            WRegions = new Regions();
            userWorkInformation = executant;
            LRegion.ItemsSource = LRegions.regions;
            WRegions.AddRegionTypeAll();
            WRegion.ItemsSource = WRegions.regions;
            
            
            Stage.ItemsSource = stageAndPositions;

            Stage.SelectionChanged += (s, e) =>
            {
                Position.ItemsSource = ((StageAndPosition)Stage.SelectedItem).Position;
                Position.ToolTip = null;
            };
            InitSelectedData();
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
            }
        }

        private void InitSelectedData()
        {
            User user = userWorkInformation.user;
            TextName.Text = user.Name; TextSurname.Text = user.Surname;  TextEmail.Text = user.Email;  TextPhone.Text=user.Phone;
            LRegion.Text = user.Region;  TextSity.Text=user.Sity;  CBirthday.Text=user.Birthday;
            if (user.UserImage != null)
            {
                var imageSource = new BitmapImage();
                MemoryStream ms;
                ms = new System.IO.MemoryStream(user.UserImage);

                imageSource.BeginInit();
                imageSource.StreamSource = ms;
                imageSource.CacheOption = BitmapCacheOption.OnLoad;
                imageSource.EndInit();

                ImageBrush img = new ImageBrush();
                img.ImageSource = imageSource;
                BImg.Background = img;
            }
            Stage.SelectedIndex = StageAndPosition.GetIndexStage(userWorkInformation.Stage);
            Position.SelectedItem = userWorkInformation.Position;
            WRegion.SelectedItem = userWorkInformation.WorkRegion; TextSalary.Text = userWorkInformation.Salary;
        }

        private void Button_Click_1(object sender, System.Windows.RoutedEventArgs e)
        {
            //Edit button

            userWorkInformation.user.Name = TextName.Text; userWorkInformation.user.Surname = TextSurname.Text; 
            userWorkInformation.user.Email = TextEmail.Text; userWorkInformation.user.Phone = TextPhone.Text;
            userWorkInformation.user.Region = LRegion.Text; userWorkInformation.user.Sity = TextSity.Text; userWorkInformation.user.Birthday = CBirthday.Text;
            if (imageName != null)
            {
                FileStream fs = new FileStream(imageName, FileMode.Open, FileAccess.Read);
                byte[] imgByteArr = new byte[fs.Length];
                fs.Read(imgByteArr, 0, Convert.ToInt32(fs.Length));
                fs.Close();

                userWorkInformation.user.UserImage = imgByteArr;
            }
            userWorkInformation.Position = Position.Text; userWorkInformation.Stage = Stage.Text;
            userWorkInformation.WorkRegion = WRegion.Text; userWorkInformation.Salary = TextSalary.Text;
            UserWorkInformationRequest.PostUpdateUWI(userWorkInformation);
        }

        private void Button_Click_2(object sender, System.Windows.RoutedEventArgs e)
        {
            UserWorkInformationRequest.DeleteUserWI((int)userWorkInformation.ID);
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
    }
}
