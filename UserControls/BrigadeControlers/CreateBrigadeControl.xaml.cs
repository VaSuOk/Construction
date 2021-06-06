using Construction.Auxiliary_classes;
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
        private List<StageAndPosition> stageAndPositions = StageAndPosition.GetCategories();

        private List<AmountUsers> amountUsers = AmountUsers.GetAmounts();
        private List<User> PickUsers;

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
    }
}
