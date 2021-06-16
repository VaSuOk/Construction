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

namespace Construction.UserControls.Task
{
    /// <summary>
    /// Логика взаимодействия для CreateTaskArchitect.xaml
    /// </summary>
    public partial class CreateTaskArchitect : UserControl
    {
        private List<UserWorkInformation> architectors;
        private List<ConstructionObject> buildObjects;
        private Regions ORegions;
        private TypeBuild typeBuild;
        private TaskArchitect taskArchitect;

        public CreateTaskArchitect()
        {
            InitializeComponent();
            ORegions = new Regions();
            typeBuild = new TypeBuild();
            WRegion.ItemsSource = ORegions.regions;
            CType.ItemsSource = typeBuild.type;
            taskArchitect = new TaskArchitect();
            architectors = UserWorkInformationRequest.GetUserByStageAndPosition("none", "Архітектування", "Архітектор");
            buildObjects = ConstructionRequest.GetALLConstOByStage(0);
            ListWorker.ItemsSource = architectors;
            InitDataConstructionList();
        }

        private void InitDataConstructionList()
        {
            if (buildObjects != null)
            {
                foreach (var item in buildObjects)
                {
                    if (item.Image.Length < 20)
                    {
                        var imageSource = new BitmapImage();
                        FileStream fs = null;
                        switch (item.TypeBuilding)
                        {
                            case "Приватний будинок":
                                {
                                    fs = new FileStream(@"D:\KPK\ДИПЛОМ\SOFT\Construction\Source\Private.png", FileMode.Open, FileAccess.Read);
                                    break;
                                }
                            case "Квартирний будинок":
                                {
                                    fs = new FileStream(@"D:\KPK\ДИПЛОМ\SOFT\Construction\Source\квартика.png", FileMode.Open, FileAccess.Read);
                                    break;
                                }
                            case "Офісний будинок":
                                {
                                    fs = new FileStream(@"D:\KPK\ДИПЛОМ\SOFT\Construction\Source\oficc.png", FileMode.Open, FileAccess.Read);
                                    break;
                                }
                            case "Виробничий будинок":
                                {
                                    fs = new FileStream(@"D:\KPK\ДИПЛОМ\SOFT\Construction\Source\заводФ.png", FileMode.Open, FileAccess.Read);
                                    break;
                                }
                            case "Оздоровчий будинок":
                                {
                                    fs = new FileStream(@"D:\KPK\ДИПЛОМ\SOFT\Construction\Source\freedom.png", FileMode.Open, FileAccess.Read);
                                    break;
                                }
                        }
                        byte[] bStream = new byte[fs.Length];
                        fs.Read(bStream, 0, Convert.ToInt32(fs.Length));
                        fs.Close();
                        item.Image = bStream;
                    }
                }

            }
            ListConstructionO.ItemsSource = buildObjects;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool tmp = false;
            var obj = ListWorker.SelectedItem;
            if (obj != null)
            {
                UserWorkInformation b = (UserWorkInformation)obj;
                taskArchitect.Architect = b; tmp = true;
                var objO = ListConstructionO.SelectedItem;
                if (objO != null)
                {
                    ConstructionObject b1 = (ConstructionObject)objO;
                    taskArchitect.constructionObject = b1; tmp = true;
                }
                else
                {
                    LogBar.Content = "Оберть будівельний об'єкт!";
                    LogBar.Visibility = Visibility.Visible; tmp = false;
                }
            }
            else
            {
                LogBar.Content = "Оберть архітектора!";
                LogBar.Visibility = Visibility.Visible;
            }
            
            if (tmp)
            {
                taskArchitect.Status = "Виконання";
                taskArchitect.DateCreation = DateTime.Now.ToString("G").Split(' ')[0];
                taskArchitect.DateEnd = DateTime.Now.ToString("G").Split(' ')[0];
                TasksRequest.CreateTasks(taskArchitect);
                LogBar.Content = "Завдання створено!";
                LogBar.Visibility = Visibility.Visible;
            } 
        }

        private void BFilter_Click(object sender, RoutedEventArgs e)
        {
            buildObjects = ConstructionRequest.GetALLConstO(WRegion.Text, "none", CType.Text);
            InitDataConstructionList();
        }

        private void BSearch_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(SearchName.Text) || !string.IsNullOrWhiteSpace(SearchSurname.Text))
            {
                architectors = FixSearch(UserWorkInformationRequest.GetUserWIByInitial(SearchName.Text, SearchSurname.Text));
                ListWorker.ItemsSource = architectors;
            }
        }
        private List<UserWorkInformation> FixSearch(List<UserWorkInformation> userWorkInformation)
        {
            List<UserWorkInformation> tmp = new List<UserWorkInformation>();
            foreach (var item in userWorkInformation)
            {
                if(item.Position == "Архітектор")
                {
                    tmp.Add(item);
                }
            }
            return tmp;
        }
    }
}
