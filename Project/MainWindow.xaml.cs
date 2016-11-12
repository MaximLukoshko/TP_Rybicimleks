using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System. Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

namespace Rybocompleks.GUI
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /*[Serializable]
        private class DataSensors
        {
            public string Name { get; set; }
            public int Value { get; set; }
            public DataSensors(string Name, int Value)
            {
                this.Name = Name;
                this.Value = Value;
            }
        }
        List<DataSensors> sensors = new List<DataSensors>();*/
        public MainWindow()
        {
            InitializeComponent();
            /*XmlDocument doc = new XmlDocument();
            doc.Load("Sensors.xml");
            foreach (XmlNode node in doc.DocumentElement)
            {
                string name = node.Attributes[0].Value;
                int value = Int32.Parse(node.Attributes[1].Value);
                sensors.Add(new DataSensors(name, value));
            }*/
        
        }

        private void FileExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SensorTable_Loaded(object sender, RoutedEventArgs e)
        {
            //SensorTable.ItemsSource = sensors;
        }      

        private void OpenGP_Click(object sender, RoutedEventArgs e)
        {
            BrowseBtn_Click(sender,e);
        }
         
        private void Run_Click(object sender, RoutedEventArgs e)
        {
            if(TxtBx_GPPath.Text!="")
            {
                if (System.IO.File.Exists(TxtBx_GPPath.Text))
                {
                    MessageBox.Show("Запуск процесса выращивания рыбы по плану из файла:\n " + TxtBx_GPPath.Text);                    
                    TabContr.Items.Add(new TabItem() { Header = "Датчки таблица" });
                    TabContr.Items.Add(new TabItem() { Header = "Датчки рисунок" });
                    TabContr.Items.Add(new GPEditor(TxtBx_GPPath.Text));
                    TabContr.Items.Remove(StartPage);
                }
                else
                    MessageBox.Show("Файл не найден", "Warning!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                MessageBox.Show("Имя файла не может быть пустым!", "Warning!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void MenuAbout_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Вывод информации о проекте");
        }

        private void BrowseBtn_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = ""; // Default file name
            dlg.DefaultExt = ".xml"; // Default file extension
            dlg.Filter = "xml documents (.xml)|*.xml"; // Filter files by extension
            // Show open file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                // Open document
                string filename = dlg.FileName;
                TxtBx_GPPath.Text = filename;
            }
        }

        private void CreatGP_Click(object sender, RoutedEventArgs e)
        {
          //  MessageBox.Show("открытие окна создания плана выращивания");          
            GPEditor gpe = new GPEditor();
            TabContr.Items.Add(gpe);
            TabContr.SelectedItem = gpe;
        }

      
    }
}
