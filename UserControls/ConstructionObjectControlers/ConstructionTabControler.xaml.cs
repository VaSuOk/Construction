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

namespace Construction.UserControls.ConstructionObjectControlers
{
    /// <summary>
    /// Логика взаимодействия для ConstructionTabControler.xaml
    /// </summary>
    public partial class ConstructionTabControler : UserControl
    {
        public ConstructionTabControler()
        {
            InitializeComponent();
            GridCreateConstructionObject.Children.Add(new CreateConstructionOControl());
        }
    }
}
