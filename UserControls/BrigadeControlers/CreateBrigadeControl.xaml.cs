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
using Сonstruction.Model;

namespace Construction.UserControls.BrigadeControlers
{
    /// <summary>
    /// Логика взаимодействия для CreateBrigadeControl.xaml
    /// </summary>
    public partial class CreateBrigadeControl : UserControl
    {
        private Regions WRegions;
        private List<StageAndPosition> stageAndPositions = StageAndPosition.Get4Categories();

        private List<AmountUsers> amountUsers = AmountUsers.GetAmounts();
        private List<UserWorkInformation> PickWorkers;

        private Brigade brigade;
        private int id;

        public CreateBrigadeControl()
        {
            InitializeComponent();
            InitAmountUsers();
            SetStage();
            WRegions = new Regions();
            brigade = new Brigade();
            WRegion.ItemsSource = WRegions.regions;
        }

        private void SetStage()
        {
            Stage.ItemsSource = stageAndPositions;
            Stage.SelectionChanged += (s, e) =>
            {
                Position.ItemsSource = ((StageAndPosition)Stage.SelectedItem).Position;
                Position.ToolTip = null;
            };
        }

        private void InitAmountUsers()
        {
            WorkerAmount.ItemsSource = amountUsers;
            WorkerAmount.SelectionChanged += (s, e) =>
            {
                ListUsers.ItemsSource = ((AmountUsers)WorkerAmount.SelectedItem).users;
                ListUsers.ToolTip = null;
            };
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (CheakInputData())
            {
                brigade.Amount = Convert.ToInt32(WorkerAmount.Text);
                brigade.Name = TextNameBrigade.Text;
                brigade.WorkRegion = WRegion.Text;
                brigade.WorkStage = Stage.Text;
                BrigadeRequest.CreateBrigade(brigade);
            }
        }
        private void search_Click(object sender, RoutedEventArgs e)
        {
                PickWorkers = UserWorkInformationRequest.GetUserByStageAndPosition( WRegion.Text, Stage.Text, Position.Text );
                ListWorker.ItemsSource = PickWorkers;
        }

        private void pick_Click(object sender, RoutedEventArgs e)
        {
            var obj = ListWorker.SelectedItem;
            if(obj != null)
            {
                UserWorkInformation b = (UserWorkInformation)obj;
                UserPick.Visibility = Visibility.Collapsed;

                ((AmountUsers)WorkerAmount.SelectedItem).users[id] = b;
                ListUsers.ItemsSource = null;
                ListUsers.ItemsSource = ((AmountUsers)WorkerAmount.SelectedItem).users;
                ListUsers.ToolTip = null;
                InitUserToBrigade(id, (int)b.ID);
            }
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            UserPick.Visibility = Visibility.Collapsed;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
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

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            id = ListUsers.SelectedIndex;
            if (id > -1)
            {
                var obj = ListWorker.SelectedItem;
                if (obj != null)
                {
                    
                    ((AmountUsers)WorkerAmount.SelectedItem).users[id] = new UserWorkInformation();
                    ListUsers.ItemsSource = null;
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
        private void InitUserToBrigade(int index, int id = 0)
        {
            switch(index)
            {
                case 0:
                    {
                        brigade.ID_user1 = id;
                        break;
                    }
                case 1:
                    {
                        brigade.ID_user2 = id;
                        break;
                    }
                case 2:
                    {
                        brigade.ID_user3 = id;
                        break;
                    }
                case 3:
                    {
                        brigade.ID_user4 = id;
                        break;
                    }
                case 4:
                    {
                        brigade.ID_user5 = id;
                        break;
                    }
                case 5:
                    {
                        brigade.ID_user6 = id;
                        break;
                    }
                case 6:
                    {
                        brigade.ID_user7 = id;
                        break;
                    }
                case 7:
                    {
                        brigade.ID_user8 = id;
                        break;
                    }
            }
        }
        private bool CheakInputData()
        {
            LogBar.Foreground = Brushes.Red;
            LogBar.Visibility = Visibility.Visible;
            if(string.IsNullOrWhiteSpace(TextNameBrigade.Text))
            {
                LogBar.Content = "Введіть назву бригади!";
            }
            else if(string.IsNullOrWhiteSpace(WRegion.Text))
            {
                LogBar.Content = "Оберіть регіон роботи!";
            }
            else if(string.IsNullOrWhiteSpace(Stage.Text))
            {
                LogBar.Content = "Оберіть етап виконання!";
            }
            else if(string.IsNullOrWhiteSpace(WorkerAmount.Text))
            {
                LogBar.Content = "Оберіть кількість учасників!";
            }
            else return true;
            return false;
        }
    }
}
