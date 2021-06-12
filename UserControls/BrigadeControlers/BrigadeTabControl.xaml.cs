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

namespace Construction.UserControls.BrigadeControlers
{
    /// <summary>
    /// Логика взаимодействия для BrigadeTabControl.xaml
    /// </summary>
    public partial class BrigadeTabControl : UserControl
    {
        public BrigadeTabControl()
        {
            InitializeComponent();
            GridCreateBrigade.Children.Add(new CreateBrigadeControl());
            GridListBrigade.Children.Add(new BrigadeListControl(ref SelectedBrigade));
        }
    }
}
