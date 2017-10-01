using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using WPF_HW1.Model;

namespace WPF_HW1.UserControls
{
    public partial class MainUserControl : UserControl
    {
        
       
        public MainUserControl()
        {
            InitializeComponent();
            
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            ListBoxItem myListBoxItem = new ListBoxItem();
            StackPanel myStackPanel = new StackPanel();
            myStackPanel.Orientation = Orientation.Horizontal;
            TextBlock myTextBlock = new TextBlock();
            myTextBlock.Text = DateTime.Now.ToString("h:mm:ss");
            myTextBlock.Margin = new Thickness(10, 0, 40, 0);
            ComboBox myComboBox = new ComboBox();
            myComboBox.Margin = new Thickness(10, 0, 40, 0);
            myComboBox.Items.Add("UTC-0");
            myComboBox.Items.Add("UTC+1");
            myComboBox.Items.Add("UTC+2");
            myComboBox.SelectedIndex = 1;
            myStackPanel.Children.Add(myTextBlock);
            myStackPanel.Children.Add(myComboBox);
            myListBoxItem.Content = myStackPanel;
            listBox.Items.Add(myListBoxItem);
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (listBox.SelectedIndex != -1)
            {
                listBox.Items.RemoveAt(listBox.SelectedIndex);
            }
            else
            {
                //Показать сообщение
            }

        }
    }
}
