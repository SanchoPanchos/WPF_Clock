using System;
using System.ComponentModel;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using WPF_HW1.Model;
using WPF_HW1.Utils;

namespace WPF_HW1.UserControls
{
    public partial class MainUserControl : UserControl
    {


        public MainUserControl()
        {
            InitializeComponent();
            if (UserManager.GetCurrentUser() != null)
            {
                welcome.Text = "Welcome, " + UserManager.GetCurrentUser()._name;
            }

        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            ListBoxItem myListBoxItem = new ListBoxItem();
            StackPanel myStackPanel = new StackPanel();
            myStackPanel.Orientation = Orientation.Horizontal;
            TextBlock myTextBlock = new TextBlock();
            Thread myThread = new Thread(SetTime);
            myThread.Start(myTextBlock);
            myTextBlock.Margin = new Thickness(10, 0, 40, 0);
            ComboBox myComboBox = new ComboBox();
            myComboBox.Margin = new Thickness(10, 0, 40, 0);
            for (int i = 0; i < Constants.TimeZones.Count; i++)
            {
               
                    myComboBox.Items.Add(Constants.TimeZones[i]);
                
            }
            myComboBox.SelectedIndex = 1;
            myComboBox.SelectionChanged += MyComboBox_SelectionChanged;
            myStackPanel.Children.Add(myTextBlock);
            myStackPanel.Children.Add(myComboBox);
            myListBoxItem.Content = myStackPanel;
            listBox.Items.Add(myListBoxItem);
            LogManager.Log(Constants.AddedNewTimeClock);
        }

        private void SetTime(object obj)
        {
            TextBlock textBlock = obj as TextBlock;
            while (true)
            {
                textBlock.Dispatcher.Invoke((Action)delegate

                {

                    textBlock.Text = DateTime.Now.ToString(Constants.TimeFormat);

                });

                Thread.Sleep(100);
            }
        }

        private void MyComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox combobox = sender as ComboBox;
            combobox.IsEnabled = false;
            listBox.Items.SortDescriptions.Add(new SortDescription("Content",
       ListSortDirection.Ascending));
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (listBox.SelectedIndex != -1)
            {
                listBox.Items.RemoveAt(listBox.SelectedIndex);
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
