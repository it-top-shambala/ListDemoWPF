using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace ListDemo.App
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public ObservableCollection<string> Collection { get; set; }

        private string _selectedItem;
        public string SelectedItem
        {
            get => _selectedItem;
            set
            {
                if (value == _selectedItem) return;

                _selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }
        
        
        public MainWindow()
        {
            Collection = new ObservableCollection<string>() {"first", "second", "last"};
            
            InitializeComponent();
        }

        private void ButtonAdd_OnClick(object sender, RoutedEventArgs e)
        {
            var input = InputItem.Text;

            if (string.IsNullOrWhiteSpace(input)) return;
            
            Collection.Add(InputItem.Text);
        }

        private void ButtonDelete_OnClick(object sender, RoutedEventArgs e)
        {
            var input = InputItem.Text;

            if (string.IsNullOrWhiteSpace(input)) return;

            Collection.Remove(input);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}