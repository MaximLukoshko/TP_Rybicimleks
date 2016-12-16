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

            UpdateSystemConditionCanvas();
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

        private void UpdateSystemConditionCanvas()
        {
            List<IShowInfo> showInfoList = (List<IShowInfo>)GrowingDispatcher.GetShowInfo();
            states = new List<SystemConditionNode>();
            foreach (IShowInfo info in showInfoList)
            {
                //пока не трогать!
                //SensorImage snsrImg = new SensorImage(info); 
                //canvas.Children.Add(snsrImg);
                //double x = info.GetItem().GetLocation().X;
                //double y = info.GetItem().GetLocation().Y;
                //x *= (int)canvas.Width / 100;
                //y *= (int)canvas.Height / 100;

                //MessageBox.Show(x+"  "+y+"   "+ (int)canvas.Height);
                //Canvas.SetLeft(snsrImg, x);
                //Canvas.SetTop(snsrImg, y);
                
            }
            dgSystemCondition.Dispatcher.Invoke(delegate { dgSystemCondition.ItemsSource = states; });

        }

        private Boolean UpdateCurrentInstructionTable()
        {
            IGPAllowedStates showingInstruction = GrowingDispatcher.GetCurrentInstruction();
            if (null == showingInstruction)
                return false;
//             currentInstruction = new GPInstruction(showingInstruction);
//             int temperMin = currentInstruction.TemperatureMin;
//             int temperMax = currentInstruction.TemperatureMax;
//             DateTime SystemTime = GrowingDispatcher.GetCurrentTime();

//             List<CurrentInstuctDescriptionTable> currInstrDescrTable = new List<CurrentInstuctDescriptionTable>() {
//                 new CurrentInstuctDescriptionTable(){ ParamName="Время", ParamValue = SystemTime.Hour+" ч.  "+SystemTime.Minute +" мин."},
//                 new CurrentInstuctDescriptionTable(){ ParamName="Стадия", ParamValue = currentInstruction.InstructionName},
//                 new CurrentInstuctDescriptionTable(){ ParamName="Температура",
//                     ParamValue = (temperMin != temperMax) ? temperMin + " - " + temperMax + " grad" : temperMax+ " grad" },                                
//                 new CurrentInstuctDescriptionTable(){ ParamName="Содержание кислорода", ParamValue = currentInstruction.Oxygen.ToString()},
//                 new CurrentInstuctDescriptionTable(){ ParamName="Уровень кислотности", ParamValue = currentInstruction.PH.ToString()},                
//             };

            List<CurrentInstuctDescriptionTable> currInstrDescrTable = new List<CurrentInstuctDescriptionTable>() {
                new CurrentInstuctDescriptionTable(){ ParamName="Время", 
                    ParamValue = GrowingDispatcher.GetCurrentTime().Hour + " ч.  " +
                                 GrowingDispatcher.GetCurrentTime().Minute +" мин."},
                new CurrentInstuctDescriptionTable(){ ParamName="Стадия", ParamValue = showingInstruction.Name},
                new CurrentInstuctDescriptionTable(){ ParamName="Выполнение инструкции", ParamValue = ((Int32)(showingInstruction.Progress*100)).ToString() + "%"},
                new CurrentInstuctDescriptionTable(){ ParamName="Температура",
                    ParamValue = showingInstruction.GetStateByPropertyID(MeasurmentTypes.Type.Temperature).ToString() + " grad" },
                new CurrentInstuctDescriptionTable(){ ParamName="Содержание кислорода", 
                    ParamValue = showingInstruction.GetStateByPropertyID(MeasurmentTypes.Type.Oxygen).ToString()},
                new CurrentInstuctDescriptionTable(){ ParamName="Уровень кислотности", 
                    ParamValue = showingInstruction.GetStateByPropertyID(MeasurmentTypes.Type.PH).ToString() },
                new CurrentInstuctDescriptionTable(){ ParamName="Освещение", 
                    ParamValue = showingInstruction.GetStateByPropertyID(MeasurmentTypes.Type.LightPerDay).ToString() + " ч/сут" },
            };

            dgCurrInstDescription.Dispatcher.Invoke(delegate { dgCurrInstDescription.ItemsSource = currInstrDescrTable; });
            
            return true;
        }
        private void MonitorSystem()
        {
            while (true == UpdateCurrentInstructionTable()) 
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
