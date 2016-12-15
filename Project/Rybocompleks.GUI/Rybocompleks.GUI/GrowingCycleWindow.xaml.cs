using Rybocompleks.GUI.Data;
using Rybocompleks.Data;
using Rybocompleks.Dispatcher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
        private GPInstruction currentInstruction;   

        private Thread MonitorSystemThread;

        public GrowingCycleWindow(IDispatcher dispatcher)
        {
            InitializeComponent();
            GrowingDispatcher = dispatcher;
            states = new List<SystemConditionNode>();
            dgSystemCondition.ItemsSource = states;
            MonitorSystemThread = new Thread(MonitorSystem);

            currentInstruction = new GPInstruction(GrowingDispatcher.GetCurrentInstruction());
            UpdateCurrentInstructionTable();


    }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GrowingDispatcher.RunFishGrowing();
            MonitorSystemThread.Start();
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

            dgSystemCondition.Dispatcher.Invoke(delegate { dgSystemCondition.ItemsSource = states; });
        }

        private void UpdateCurrentInstructionTable()
        {
            currInstDescription_TxtBlck.Text = currentInstruction.InstructionName;
        }
        private void DisplayStates(List<SystemConditionNode> states)
        {
            dgSystemCondition.ItemsSource = states;
        }

        private void MonitorSystem()
        {
            while(true)
            {
                UpdateSystemConditionTable();
                Thread.Sleep(500);
            }
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
            MonitorSystemThread.Abort();
            GrowingDispatcher.StopFishGrowing();
        }

        private void MenuItemExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
