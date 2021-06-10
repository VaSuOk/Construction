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

namespace Construction.UserControls.Task
{
    /// <summary>
    /// Логика взаимодействия для TaskTabController.xaml
    /// </summary>
    public partial class TaskTabController : UserControl
    {
        public TaskTabController()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Tasks.SelectedIndex++;
        }
    }
}
