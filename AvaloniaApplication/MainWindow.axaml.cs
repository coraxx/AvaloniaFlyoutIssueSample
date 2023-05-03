using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Styling;

namespace AvaloniaApplication
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private bool _option1;

        public bool Option1
        {
            get => _option1;
            set
            {
                if (value == _option1) return;
                _option1 = value;
                OnPropertyChanged();
            }
        }
        private bool _option2;

        public bool Option2
        {
            get => _option2;
            set
            {
                if (value == _option2) return;
                _option2 = value;
                OnPropertyChanged();
            }
        }

        public ThemeVariant[] ThemeVariants { get; } = new[]
        {
            ThemeVariant.Default,
            ThemeVariant.Dark,
            ThemeVariant.Light
        };

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            ThemeSelect2.ItemsSource = ThemeVariants;  // Needed, otherwise change does not apply correctly ?!
            ThemeSelect1.SelectedItem = ThemeVariant.Dark;
            ThemeSelect2.SelectedItem = ThemeVariant.Dark;
        }

        private void Option1_OnIsCheckedChanged(object? sender, RoutedEventArgs e)
        {
            Debug.WriteLine($"Option1 checked change triggered! IsChecked: {((CheckBox)sender!)?.IsChecked}; IsLoaded: {((CheckBox)sender!)?.IsLoaded}");
        }

        private void Option2_OnIsCheckedChanged(object? sender, RoutedEventArgs e)
        {
            Debug.WriteLine($"Option2 checked change triggered! IsChecked: {((CheckBox)sender!)?.IsChecked}; IsLoaded: {((CheckBox)sender!)?.IsLoaded}");
        }

        private void ThemeSelect1_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
        {
            Debug.WriteLine("ComboBox1 changed selection triggered");
            if (Application.Current != null && sender is ComboBox cb && cb.SelectedItem != null)
                Application.Current.RequestedThemeVariant = (ThemeVariant)cb.SelectedItem;
        }

        private void ThemeSelect2_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
        {
            Debug.WriteLine("ComboBox2 changed selection triggered");
            if (Application.Current != null && sender is ComboBox cb && cb.SelectedItem != null)
                Application.Current.RequestedThemeVariant = (ThemeVariant)cb.SelectedItem;
        }

        public new event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}