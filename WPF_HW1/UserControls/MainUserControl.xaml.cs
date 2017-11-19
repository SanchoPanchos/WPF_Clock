using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using System.Linq;
using System.Windows.Controls;
using WPF_HW1.Model;
using WPF_HW1.Utils;

namespace WPF_HW1.UserControls
{
    public partial class MainUserControl : UserControl
    {
        private MainWindow parentWindow;

        public MainUserControl()
        {
            InitializeComponent();
            logoutButton.Click += LogoutButton_Click;
            parentWindow = Application.Current.MainWindow as MainWindow;
            welcome.Text = "Welcome, " + UserManager.GetCurrentUser().Name;
            FillTimeClocks();
            
        }

        private void FillTimeClocks()
        {
            List<TimeClock> timeClocks = EntityWrapper.GetTimeClocksByUserId(UserManager.GetCurrentUser().Guid);
            List<TimeClockItem> timeClockItems = new List<TimeClockItem>();
            for(int i = 0; i < timeClocks.Count; i++)
            {
                timeClockItems.Add(new TimeClockItem(timeClocks[i].Offset, timeClocks[i].Name, timeClocks[i].Guid));
            }
            listBox.ItemsSource = timeClockItems;
            for (int i = 0; i < timeClockItems.Count; i++)
            {
                AddThread(timeClockItems[i]);
            }
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            ReadWriteManager.DeleteFile(Constants.ClientDataDirPath, "Data", ".txt");
            parentWindow.ShowLogin();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            List<TimeClockItem> list = listBox.Items.Cast<TimeClockItem>().ToList();
            if (list.Count == Constants.TimeZonesNames.Count)
            {
                addButton.IsEnabled = false;
                return;
            }   
            //Вытащить список уже добавленных
            List<String> newList = new List<String>();
            newList.InsertRange(0, Constants.TimeZonesNames);
            //Создать стринговый список из оставшися незанятых названий зон
            for (int i =0; i < list.Count; i++)
            {
                newList.Remove(list[i].SelectedName);
            }
            newList.Insert(0, "<Please select ...>");

            //засетить
            TimeClockItem item = new TimeClockItem(newList);
            item.ComboBox.SelectionChanged += ComboBox_SelectionChanged;

            List<TimeClockItem> temp = listBox.Items.Cast<TimeClockItem>().ToList();
            temp.Add(item);
            listBox.ItemsSource = temp;
            LogManager.Log(Constants.AddedNewTimeClock);
            addButton.IsEnabled = false;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox combobox = sender as ComboBox;
            List<TimeClockItem> list = listBox.Items.Cast<TimeClockItem>().ToList();
            for(int i = 0; i < list.Count; i++)
            {
                if (list[i].ComboBox.Equals(combobox))
                {
                    list[i].SelectedName = combobox.SelectedValue.ToString();
                    for(int j = 0; j < Constants.TimeZonesNames.Count; j++)
                    {
                        if (Constants.TimeZonesNames[j].Equals(combobox.SelectedValue.ToString()))
                        {
                            list[i].Offset = j - 11;
                            list[i].TextBlock.Text = list[i].Offset.ToString();
                            AddThread(list[i]);
                            TimeClock temp = new TimeClock(list[i].Offset, list[i].SelectedName, UserManager.GetCurrentUser());
                            EntityWrapper.AddTimeClock(temp);
                            list[i].Guid = temp.Guid;
                            break;
                        }
                    }
                }
            }
            combobox.IsEnabled = false;
            addButton.IsEnabled = true;
        }

        private void AddThread(TimeClockItem item)
        {
            Thread myThread = new Thread(SetTime);
            myThread.Start(item);
        }

        private void SetTime(Object obj)
        {
            TimeClockItem item = obj as TimeClockItem;
            
            while (true)
            {
                item.TextBlock.Dispatcher.Invoke((Action)delegate

                {

                    item.TextBlock.Text = DateTime.Now.AddHours(item.Offset).ToString(Constants.TimeFormat);

                });

                Thread.Sleep(100);
            }
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (listBox.SelectedIndex != -1)
            {
                List<TimeClockItem> list = listBox.Items.Cast<TimeClockItem>().ToList();
                EntityWrapper.DeleteTimeClock(list[listBox.SelectedIndex].Guid);
                list.RemoveAt(listBox.SelectedIndex);
                listBox.ItemsSource = list;
                LogManager.Log(Constants.RemovedTimeClock);
            }
            else
            {
                try
                {
                    LogManager.Log(Constants.NoItemSelected);
                }
                catch (TypeInitializationException ex)
                {
                    Console.WriteLine(ex.InnerException);
                }

            }

        }
    }
}
