using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace WPF_HW1.Model
{
    class TimeClockItem : ListBoxItem
    {
        public int _offset;
        public List<String> _names;
        public String _selectedName;
        public ComboBox _comboBox;
        public TextBlock _textBlock;
        public StackPanel _stackPanel;
        public Guid _guid;

        public TimeClockItem(List<String> names)
        {
            DefaultPanel();
            _names = names;
            _comboBox.ItemsSource = names;
        }

        public TimeClockItem(int offset, String name, Guid guid)
        {
            DefaultPanel();
            _selectedName = name;
            _offset = offset;
            _comboBox.Items.Add(name);
            _comboBox.SelectedItem = name;
            _guid = guid;
            _comboBox.IsEnabled = false;
        }

        private void DefaultPanel()
        {
            _stackPanel = new StackPanel();
            _stackPanel.Orientation = Orientation.Horizontal;
            _textBlock = new TextBlock();
            _textBlock.Margin = new Thickness(10, 0, 0, 0);
            _comboBox = new ComboBox();
            _comboBox.Margin = new Thickness(60, 0, 0, 0);
            _comboBox.SelectedIndex = 0;
            _stackPanel.Children.Add(_textBlock);
            _stackPanel.Children.Add(_comboBox);
            Content = _stackPanel;
        }


        public TimeClockItem()
        {

        }

        public int Offset
        {
            get
            {
                return _offset;
            }
            set
            {
                _offset = value;
            }
        }

        public Guid Guid
        {
            get
            {
                return _guid;
            }
            set
            {
                _guid = value;
            }
        }

        public ComboBox ComboBox
        {
            get
            {
                return _comboBox;
            }
            set
            {
                _comboBox = value;
            }
        }

        public TextBlock TextBlock
        {
            get
            {
                return _textBlock;
            }
            set
            {
                _textBlock = value;
            }
        }

        public StackPanel StackPanel
        {
            get
            {
                return _stackPanel;
            }
            set
            {
                _stackPanel = value;
            }
        }

        public String SelectedName
        {
            get
            {
                return _selectedName;
            }
            set
            {
                _selectedName = value;
            }
        }

        public List<String> Names
        {
            get
            {
                return _names;
            }
            set
            {
                _names = value;
            }
        }
 
    }
}
