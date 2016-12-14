using Rybocompleks.Data;
using Rybocompleks.Dispatcher;
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
    /// Логика взаимодействия для GrowingCycleWindow.xaml
    /// </summary>
    public partial class GrowingCycleWindow : Window
    {
        private IDispatcher GrowingDispatcher;
        private List<SystemConditionNode> states;         
        public GrowingCycleWindow(IDispatcher dispatcher)
        {
            InitializeComponent();
            GrowingDispatcher = dispatcher;
            states = new List<SystemConditionNode>();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GrowingDispatcher.RunFishGrowing();
            UpdateSystemConditionTable();          
        }
        private void UpdateSystemConditionTable()
        {
            List<IShowInfo> showInfoList = (List<IShowInfo>)GrowingDispatcher.GetShowInfo();
            //var states= from info in showInfoList select info.GetState().GetStringValue();
            states = new List<SystemConditionNode>();
            foreach (IShowInfo info in showInfoList)
            {
                string state = info.GetState().GetStringValue();
                string name = info.GetItem().Name;
                states.Add(new SystemConditionNode(name, state));
            }
            dgSystemCondition.ItemsSource = null;            
            dgSystemCondition.ItemsSource = states;            
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string msg = "Цикл выращивания будет прерван! Продолжить?";
            MessageBoxResult result = MessageBox.Show(msg,"Выход",MessageBoxButton.YesNo,MessageBoxImage.Warning);
            if (result == MessageBoxResult.No)
            {
                e.Cancel = true;
            }      
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            GrowingDispatcher.StopFishGrowing();
        }

        private void MenuItemExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
