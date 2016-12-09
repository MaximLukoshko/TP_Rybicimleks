using System;
using System.Collections.Generic;
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

namespace Rybocompleks.GUI
{
    /// <summary>
    /// Логика взаимодействия для SelectStringWindow.xaml
    /// </summary>
    public partial class SelectStringWindow : Window
    {
        int maxValue;
        public SelectStringWindow(int maxValue)
        {
            InitializeComponent();
            this.maxValue = maxValue;
            txtBlock.Text = "Введите номер строки (1 - " + maxValue.ToString() + "):";
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
        public int LineNumber
        {
            get 
            {
                int result;
                try
                {                    
                    result = Int32.Parse(lineNumbBox.Text);
                    if (result > maxValue || result < 0)
                        throw new FormatException();
                }
                catch (FormatException e)
                {
                    MessageBox.Show("Неверный формат", "Ошибка " + e.ToString(), MessageBoxButton.OK, MessageBoxImage.Error);
                    result = 0;
                }
                return result; 
            }
        }
    }
}
