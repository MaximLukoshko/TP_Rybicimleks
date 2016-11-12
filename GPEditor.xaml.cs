using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
using System.Xml.Serialization;

namespace Rybocompleks.GUI
{
    /// <summary>
    /// Логика взаимодействия для GPEditor.xaml
    /// </summary>
    public partial class GPEditor : TabItem
    {
        private ObservableCollection<GPNode> GP;
        private string filePath { get; set;}
        private void LoadGP(string path)
        {           
            if (!System.IO.File.Exists(path))
            {
                MessageBox.Show("указанный файл (" + path + ") отсутсвует");
            }
            XmlSerializer formatter = new XmlSerializer(typeof(ObservableCollection<GPNode>));
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                GP = (ObservableCollection<GPNode>)formatter.Deserialize(fs);                
            }
        }
        private void SaveGP(string path)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(ObservableCollection<GPNode>));
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, GP);
            }
        }
        public GPEditor()
        {
            GP = new ObservableCollection<GPNode>();
            InitializeComponent();
            dataGrid.ItemsSource = GP;
        }
        public GPEditor(string path)
        {
            InitializeComponent();
            GP = new ObservableCollection<GPNode>();
            if (System.IO.File.Exists(path))
                filePath = path;
            LoadGP(filePath);
            dataGrid.ItemsSource = GP;
        } 

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "План выращивания"; // Default file name
            dlg.DefaultExt = ".xml"; // Default file extension
            dlg.Filter = "xml documents (.xml)|*.xml"; // Filter files by extension
            // Show open file dialog box
            Nullable<bool> result = dlg.ShowDialog();
            // Process open file dialog box results
            if (result == true)
            {                
                filePath = dlg.FileName;
                SaveGP(dlg.FileName);                
            }
        }
        private void delSelectedGPNode(object sender, RoutedEventArgs e)
        {
            int i = dataGrid.SelectedIndex;
            GP.Remove(GP[i]);
        }

        private void closeGPEditor(object sender, RoutedEventArgs e)
        {
           TabControl gpe = (TabControl)gpEditor.Parent;
           gpe.Items.RemoveAt(gpe.SelectedIndex);
        }

        private void openBtn_Click(object sender, RoutedEventArgs e)
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
                filePath = dlg.FileName;
                LoadGP(dlg.FileName);
                dataGrid.ItemsSource = null;
                dataGrid.ItemsSource = GP;
            }
        }
        
    }
}
