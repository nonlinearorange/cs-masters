using System;
using System.ComponentModel;
using System.Windows;

namespace TravelPlanner.DesktopApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            DataContext = new MainWindowViewModel();
            InitializeComponent();
        }

        internal MainWindowViewModel? ViewModel => DataContext as MainWindowViewModel;

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            if(ViewModel == null) return;
            if (DesignerProperties.GetIsInDesignMode(this)) return;

            Loaded += OnLoaded;
            SearchButton.Click += SearchButtonClick;
        }

        private async void SearchButtonClick(object sender, RoutedEventArgs e)
        {
            if (ViewModel == null) return;
            await ViewModel.Search();
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            ViewModel?.Load();
        }
    }
}
