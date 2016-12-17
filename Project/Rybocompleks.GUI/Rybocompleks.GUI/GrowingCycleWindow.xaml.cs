﻿using Perepherial.ActiveSensors;
using Rybocompleks.Perepherial;
using Rybocompleks.GUI.UIElements;
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

        private List<UIElement> mapForIUEl = new List<UIElement>();

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
            CrateSystemConditionCanvas();            
         
            UpdateSystemConditionCanvas();
            MonitorSystemThread.Start();
        }
        private void UpdateSystemConditionTable()
        {          
            List<IShowInfo> showInfoList = (List<IShowInfo>)GrowingDispatcher.GetShowInfo();
            states = new List<SystemConditionNode>();
            foreach (IShowInfo info in showInfoList)
            {
                string name = info.GetItem().Name;
                if (name == "")
                    continue;

                string state = info.GetState().GetStringValue();
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
                
                string name = info.GetItem().Name;
                if (name == "")
                    continue;

                string state = info.GetState().GetStringValue();
                states.Add(new SystemConditionNode(name, state));
            }
            int i = 0;
            foreach(IHaveProp_Value el in mapForIUEl)
            {
                ((UIElement)el).Dispatcher.Invoke(delegate { el.Value = states[i].ElementState;});
                i++;
            }
        }

        private void CrateSystemConditionCanvas()
        {
            canvas.Dispatcher.Invoke(delegate { canvas.Children.Clear(); });            
            List<IShowInfo> showInfoList = (List<IShowInfo>)GrowingDispatcher.GetShowInfo();
            states = new List<SystemConditionNode>();            
            foreach (IShowInfo info in showInfoList)
            {
                IPhysicalObject phObj = (IPhysicalObject)info.GetItem();
                UIElement tUI = new UIElement();              
                if (phObj is TemperatureSensor)
                {
                    tUI = new TemperatureSensorUI();
                    ((TemperatureSensorUI)tUI).Value = info.GetState().GetStringValue();
                    ((TemperatureSensorUI)tUI).CaptionLbl.Content = info.GetItem().Name;
                    canvas.Children.Add((TemperatureSensorUI)tUI);                    
                }
                if (phObj is OxygenSensor)
                {
                    tUI = new OxygenSensorUI();
                    ((OxygenSensorUI)tUI).Value = info.GetState().GetStringValue();
                    ((OxygenSensorUI)tUI).CaptionLbl.Content = info.GetItem().Name;
                    canvas.Children.Add((OxygenSensorUI)tUI);
                }
                if (phObj is PhSensor)
                {
                    tUI = new PhSensorUI();
                    ((PhSensorUI)tUI).Value = info.GetState().GetStringValue();
                    ((PhSensorUI)tUI).CaptionLbl.Content = info.GetItem().Name;
                    canvas.Children.Add((PhSensorUI)tUI);
                }
                if (phObj is PhDevice)
                {
                    tUI = new PhDeviceUI();
                    ((PhDeviceUI)tUI).Value = info.GetState().GetStringValue();
                    ((PhDeviceUI)tUI).CaptionLbl.Content = info.GetItem().Name;
                    canvas.Children.Add((PhDeviceUI)tUI);
                }
                if (phObj is OxygenDevice)
                {
                    tUI = new OxygenDeviceUI();
                    ((OxygenDeviceUI)tUI).Value = info.GetState().GetStringValue();
                    ((OxygenDeviceUI)tUI).CaptionLbl.Content = info.GetItem().Name;
                    canvas.Children.Add((OxygenDeviceUI)tUI);
                }

                if (phObj is TemperatureDevice)
                {
                    tUI = new TemperatureDeviceUI();
                    ((TemperatureDeviceUI)tUI).Value = info.GetState().GetStringValue();
                    ((TemperatureDeviceUI)tUI).CaptionLbl.Content = info.GetItem().Name;
                    canvas.Children.Add((TemperatureDeviceUI)tUI);
                }
                if (phObj is LightDevice)
                {
                    tUI = new LightDeviceUI();
                    ((LightDeviceUI)tUI).Value = info.GetState().GetStringValue();
                    ((LightDeviceUI)tUI).CaptionLbl.Content = info.GetItem().Name;
                    canvas.Children.Add((LightDeviceUI)tUI);
                }
                if(phObj is ActiveTemperatureSensor)            
                {
                    tUI = new ActiveTemperatureSensorUI();
                    ((ActiveTemperatureSensorUI)tUI).Value = info.GetState().GetStringValue();
                    ((ActiveTemperatureSensorUI)tUI).CaptionLbl.Content = info.GetItem().Name;
                    canvas.Children.Add((ActiveTemperatureSensorUI)tUI);
                }
                if(phObj is LightSensor){ }
                else
                    mapForIUEl.Add(tUI);
                

                double x = info.GetItem().GetLocation().X;
                double y = info.GetItem().GetLocation().Y;
                x *= (canvas.ActualWidth-80) / 100;
                y *= (canvas.ActualHeight-100) / 100;
                Canvas.SetTop(tUI, y);
                Canvas.SetLeft(tUI, x);                
            }
           // dgSystemCondition.Dispatcher.Invoke(delegate { dgSystemCondition.ItemsSource = states; });

        }

        private Boolean UpdateCurrentInstructionTable()
        {
            IGPAllowedStates showingInstruction = GrowingDispatcher.GetCurrentInstruction();
            if (null == showingInstruction)
                return false;
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
            progressInstrBar.Dispatcher.Invoke(delegate { progressInstrBar.Value = showingInstruction.Progress * 100; });
            return true;
        }
      
        private void MonitorSystem()
        {
            while (true == UpdateCurrentInstructionTable()) 
            {
                UpdateSystemConditionTable();
                UpdateSystemConditionCanvas();
                Thread.Sleep(500);
            }
            string msg = "Выращивание завершено";
            MessageBoxResult result = MessageBox.Show(msg, "Отчёт", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //Если выращивание завершено, просто закрываем окно
            if (null == GrowingDispatcher.GetCurrentInstruction())
                return;

            string msg = "Цикл выращивания будет прерван! Продолжить?";
            MessageBoxResult result = MessageBox.Show(msg, "Выход", MessageBoxButton.YesNo, MessageBoxImage.Warning);
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
