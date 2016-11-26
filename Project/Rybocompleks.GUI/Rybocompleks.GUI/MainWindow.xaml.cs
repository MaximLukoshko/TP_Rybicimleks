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
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace Rybocompleks.GUI
{
       public partial class MainWindow : Window    
       {
           private ObservableCollection<GPNode> gpList= new ObservableCollection<GPNode>();
           private string gpFilePath = null;
           private void LoadGP()
           {
               if (!System.IO.File.Exists(gpFilePath))
               {
                   MessageBox.Show("указанный файл (" + gpFilePath + ") отсутсвует", "Ошибка!");
               }
               XmlSerializer formatter = new XmlSerializer(typeof(ObservableCollection<GPNode>));
               using (FileStream fs = new FileStream(gpFilePath, FileMode.OpenOrCreate))
               {
                   gpList = (ObservableCollection<GPNode>)formatter.Deserialize(fs);
               }
           }
           private bool SaveGP()
           {
               XmlSerializer formatter = new XmlSerializer(typeof(ObservableCollection<GPNode>));
               
               if (File.Exists(gpFilePath)) File.Delete(gpFilePath);                   

               using (FileStream fs = new FileStream(gpFilePath, FileMode.OpenOrCreate))
               {
                   formatter.Serialize(fs, gpList);
                   return true;
               }            
           }
           private void UpdateWindow()
           {
              // if(gpFilePath!= null)              
               // this.Title = gpFilePath + " - Рыбокомплекс";
              // else
              //  this.Title = "Новый палан - Рыбокомплекс";
               gpDataGrid.ItemsSource = null;
               gpDataGrid.ItemsSource = gpList;
           }
           
           public MainWindow()
            {
                InitializeComponent();
                gpDataGrid.ItemsSource = gpList;
            }

           private void SaveAs_BtnClick(object sender, RoutedEventArgs e)
               {
                   Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
                   dlg.FileName = "План выращивания"; // Default file name
                   dlg.DefaultExt = ".xml"; // Default file extension
                   dlg.Filter = "xml documents (.xml)|*.xml"; // Filter files by extension
                   // Show open file dialog box
                   Nullable<bool> result = dlg.ShowDialog();
                   if (result == true)
                   {
                       gpFilePath = dlg.FileName;
                       bool tmp = SaveGP();
                       if (tmp)
                       {
                           MessageBox.Show("Сохранено");
                       }
                       else
                       {
                           MessageBox.Show("Не сохранено");
                       }
                   }
               }

           private void Save_BtnClick(object sender, RoutedEventArgs e)
           {
                if (!File.Exists(gpFilePath))
                {
                    SaveAs_BtnClick(sender, e);
                }
                else
                {
                    bool tmp = SaveGP();
                    if (tmp)
                    {
                        MessageBox.Show("Сохранено");
                    }
                    else
                    {
                        MessageBox.Show("Не сохранено");
                    }
                }
            }
           
           private void Open_BtnClick(object sender, RoutedEventArgs e)
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
                   gpFilePath = dlg.FileName;
                   LoadGP();
                   UpdateWindow();
               }     
           }

           private void New_BtnClick(object sender, RoutedEventArgs e)
           {
               MessageBoxResult dialogResult = MessageBox.Show("Все несохранённые данные будут утеряны! \nПродолжить?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Warning);
               if (dialogResult == MessageBoxResult.Yes)
               {
                   gpFilePath = null;
                   gpList = new ObservableCollection<GPNode>();
                   UpdateWindow();
               }               
           }

           private void Exit_Click(object sender, RoutedEventArgs e)
           {
               MessageBoxResult dialogResult = MessageBox.Show("Все несохранённые данные будут утеряны! \nВыйти?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Warning);
               if (dialogResult == MessageBoxResult.Yes)
                   this.Close();                
           }

           private void del_BtnClick(object sender, RoutedEventArgs e)
           {
               int i = gpDataGrid.SelectedIndex;
               try
               {
                   gpList.Remove(gpList[i]);
               }
               catch (ArgumentOutOfRangeException)
               { }
           }

           private void RunGC_BtnClick(object sender, RoutedEventArgs e)
           {
               GrowingCycleWindow gcw = new GrowingCycleWindow();
               gcw.Show();
           }
        
      }

}
