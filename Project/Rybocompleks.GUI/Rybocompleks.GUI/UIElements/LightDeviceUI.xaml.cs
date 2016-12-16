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
    /// Логика взаимодействия для LightDeviceUI.xaml
    /// </summary>
    public partial class LightDeviceUI : UserControl
    {
        private bool _isChecked = false;
        public bool isChecked {
            get
            {
                return _isChecked;
            }
            set
            {
                if (value != _isChecked)
                {
                    _isChecked = value;
                    if (isChecked)                    
                        img.Source =  new BitmapImage(new Uri(pathToImageOn, UriKind.Relative));                    
                    else                   
                        img.Source = new BitmapImage(new Uri(pathToImageOff, UriKind.Relative));                    
                }
            }
        }
        private string pathToImageOn;
        private string pathToImageOff;
        public LightDeviceUI()
        {
            InitializeComponent();
            pathToImageOff = "Content/lightOff.png";
            pathToImageOn = "Content/lightOn.png";
                        
        }

    }
}
