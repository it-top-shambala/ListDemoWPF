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
            _list.Add(InputItem.Text);
            
            List.ItemsSource = null;
            List.ItemsSource = _list;
        }
    }
}