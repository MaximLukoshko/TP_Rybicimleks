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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Rybocompleks.GUI.UIElements
{
    /// <summary>
    /// Логика взаимодействия для PhDeviceUI.xaml
    /// </summary>
    public partial class PhDeviceUI : UserControl
    {
        private string phValue;
        public string PhValue
        {
            get
            {
                return phValue;
            }
            set
            {
                phValue = value;
                value_lbl.Content = phValue;
            }
        }
        public PhDeviceUI()
        {
            InitializeComponent();
            value_lbl.Content = phValue;
        }
    }
}
