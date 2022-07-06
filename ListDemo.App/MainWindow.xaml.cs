using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace ListDemo.App
{
    public partial class MainWindow : Window
    {
        private readonly List<string> _list;
        
        public MainWindow()
        {
            _list = new List<string> {"first", "second", "last"};
            
            InitializeComponent();

            List.ItemsSource = _list;
        }

        private void List_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            InputItem.Text = (string)((ListBox)sender).SelectedItem;
        }

        private void ButtonAdd_OnClick(object sender, RoutedEventArgs e)
        {
            var input = InputItem.Text;

            if (string.IsNullOrWhiteSpace(input)) return;
            
            _list.Add(InputItem.Text);
            
            List.ItemsSource = null;
            List.ItemsSource = _list;
        }

        private void ButtonDelete_OnClick(object sender, RoutedEventArgs e)
        {
            var input = InputItem.Text;

            if (string.IsNullOrWhiteSpace(input)) return;

            if(!_list.Remove(input)) return;
            
            List.ItemsSource = null;
            List.ItemsSource = _list;
        }

        private void InputItem_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(InputItem.Text))
            {
                ButtonAdd.IsEnabled = false;
                ButtonDelete.IsEnabled = false;
            }
            else
            {
                ButtonAdd.IsEnabled = true;
                ButtonDelete.IsEnabled = true;
            }
        }
    }
}