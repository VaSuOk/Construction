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
        private int id;

        public CreateBrigadeControl()
        {
            

            InitializeComponent();
            InitAmountUsers();
            SetStage();
            WRegions = new Regions();
 
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

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            id = ListUsers.SelectedIndex - 1;
            UserPick.Visibility = Visibility.Visible;
        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
                PickWorkers = UserWorkInformationRequest.GetUserByStageAndPosition( Stage.Text, Position.Text );
                ListWorker.ItemsSource = PickWorkers;
        }

        private void pick_Click(object sender, RoutedEventArgs e)
        {
            var obj = ListWorker.SelectedItem;
            if(obj != null)
            {
                UserWorkInformation b = (UserWorkInformation)obj;
                UserPick.Visibility = Visibility.Collapsed;

                //var tmp = ListUsers.SelectedItem;
                //UserWorkInformation userWI = (UserWorkInformation)tmp;
                //userWI = b;
                ((AmountUsers)WorkerAmount.SelectedItem).users[id] = b;
                ListUsers.ItemsSource = ((AmountUsers)WorkerAmount.SelectedItem).users;
                ListUsers.ToolTip = null;
            }
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            UserPick.Visibility = Visibility.Collapsed;
        }
    }
}
