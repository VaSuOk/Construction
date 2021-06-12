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

namespace Construction.UserControls.BrigadeControlers
{
    /// <summary>
    /// Логика взаимодействия для SeletedBrigadeInfoControl.xaml
    /// </summary>
    public partial class SeletedBrigadeInfoControl : UserControl
    {
        private List<StageAndPosition> stageAndPositions = StageAndPosition.GetCategories();
        private ViewBrigade viewBrigade1;
        private Regions WRegions;
        private List<UserWorkInformation> PickWorkers;
        private List<AmountUsers> amountUsers;
        private int id;

        public SeletedBrigadeInfoControl(ViewBrigade viewBrigade)
        {
            InitializeComponent();
            WRegions = new Regions();
            this.viewBrigade1 = viewBrigade;
            WRegion.ItemsSource = WRegions.regions;
            amountUsers = AmountUsers.GetAmountUsers(viewBrigade.brigade.Amount, viewBrigade.brigade);
            InitSelectedInfo();
        }
        private void InitSelectedInfo()
        {
            TextNameBrigade.Text = viewBrigade1.brigade.Name;
            Stage.ItemsSource = stageAndPositions;

            Stage.SelectionChanged += (s, e) =>
            {
                Position.ItemsSource = ((StageAndPosition)Stage.SelectedItem).Position;
                Position.ToolTip = null;
            };
            
            Stage.SelectedIndex = StageAndPosition.GetIndexStage(viewBrigade1.brigade.WorkStage);
            WRegion.SelectedItem = viewBrigade1.brigade.WorkRegion; 
            WorkerAmount.ItemsSource = amountUsers;
            WorkerAmount.SelectedItem = viewBrigade1.brigade.Amount;
            WorkerAmount.SelectionChanged += (s, e) =>
            {
                ListUsers.ItemsSource = ((AmountUsers)WorkerAmount.SelectedItem).users;
                ListUsers.ToolTip = null;
            };
            WorkerAmount.SelectedIndex = AmountUsers.Index;

            TextStatus.Text = viewBrigade1.wStatus;
            CircleStatus.Foreground = viewBrigade1.brush;
        }

        private void DeleteBrigade_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {

        }

        private bool CheakInputData()
        {
            LogBar.Foreground = Brushes.Red;
            LogBar.Visibility = Visibility.Visible;
            if (string.IsNullOrWhiteSpace(TextNameBrigade.Text))
            {
                LogBar.Content = "Введіть назву бригади!";
            }
            else if (string.IsNullOrWhiteSpace(WRegion.Text))
            {
                LogBar.Content = "Оберіть регіон роботи!";
            }
            else if (string.IsNullOrWhiteSpace(Stage.Text))
            {
                LogBar.Content = "Оберіть етап виконання!";
            }
            else if (string.IsNullOrWhiteSpace(WorkerAmount.Text))
            {
                LogBar.Content = "Оберіть кількість учасників!";
            }
            else return true;
            return false;
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            if (CheakInputData())
                {
                    if (ListUsers.SelectedIndex > -1)
                    {
                        LogBar.Visibility = Visibility.Hidden;
                        id = ListUsers.SelectedIndex;
                        UserPick.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        LogBar.Content = "Оберіть поле працівника!";
                        LogBar.Visibility = Visibility.Visible;
                    }
            }
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            id = ListUsers.SelectedIndex;
            if (id > -1)
            {
                var obj = ListUsers.SelectedItem;
                if (obj != null)
                {

                    ((AmountUsers)WorkerAmount.SelectedItem).users[id] = new UserWorkInformation();
                    ListUsers.ItemsSource = ((AmountUsers)WorkerAmount.SelectedItem).users;
                    ListUsers.ToolTip = null;
                    InitUserToBrigade(id);
                }
            }
            else
            {
                LogBar.Content = "Оберіть поле працівника!";
                LogBar.Visibility = Visibility.Visible;
            }
        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
            PickWorkers = UserWorkInformationRequest.GetUserByStageAndPosition(WRegion.Text, Stage.Text, Position.Text);
            ListWorker.ItemsSource = PickWorkers;
        }

        private void InitUserToBrigade(int index, int id = 0)
        {
            switch (index)
            {
                case 0:
                    {
                        viewBrigade1.brigade.ID_user1 = id;
                        break;
                    }
                case 1:
                    {
                        viewBrigade1.brigade.ID_user2 = id;
                        break;
                    }
                case 2:
                    {
                        viewBrigade1.brigade.ID_user3 = id;
                        break;
                    }
                case 3:
                    {
                        viewBrigade1.brigade.ID_user4 = id;
                        break;
                    }
                case 4:
                    {
                        viewBrigade1.brigade.ID_user5 = id;
                        break;
                    }
                case 5:
                    {
                        viewBrigade1.brigade.ID_user6 = id;
                        break;
                    }
                case 6:
                    {
                        viewBrigade1.brigade.ID_user7 = id;
                        break;
                    }
                case 7:
                    {
                        viewBrigade1.brigade.ID_user8 = id;
                        break;
                    }
            }
        }

        private void pick_Click(object sender, RoutedEventArgs e)
        {
            var obj = ListWorker.SelectedItem;
            if (obj != null)
            {
                UserWorkInformation b = (UserWorkInformation)obj;
                UserPick.Visibility = Visibility.Collapsed;

                ((AmountUsers)WorkerAmount.SelectedItem).users[id] = b;
                ListUsers.ItemsSource = ((AmountUsers)WorkerAmount.SelectedItem).users;
                ListUsers.ToolTip = null;
                InitUserToBrigade(id, (int)b.ID);
            }
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            UserPick.Visibility = Visibility.Collapsed;
        }

        private void CloseUser_Click(object sender, RoutedEventArgs e)
        {
            UserInfo.Visibility = Visibility.Collapsed;
        }

        private void ListUsers_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if(ListUsers.SelectedIndex > -1)
            {
                var obj = ListUsers.SelectedItem;
                if (obj != null)
                {
                    UserWorkInformation b = (UserWorkInformation)obj;
                    if(b.user != null)
                    {
                        var imageSource = new BitmapImage();
                        MemoryStream ms;
                        ms = new System.IO.MemoryStream(b.user.UserImage);

                        imageSource.BeginInit();
                        imageSource.StreamSource = ms;
                        imageSource.CacheOption = BitmapCacheOption.OnLoad;
                        imageSource.EndInit();

                        ImageBrush img = new ImageBrush();
                        img.ImageSource = imageSource;
                        BImg.Background = img;
                        TextName.Text = b.user.Name;
                        TextSurname.Text = b.user.Surname;
                        TextEmail.Text = b.user.Email;
                        TextPhone.Text = b.user.Phone;
                        LRegion.Text = b.user.Region;
                        TextSity.Text = b.user.Sity;
                        CBirthday.Text = b.user.Birthday;
                        UserInfo.Visibility = Visibility.Visible;
                    }
                }
                
            }
        }
    }
}
