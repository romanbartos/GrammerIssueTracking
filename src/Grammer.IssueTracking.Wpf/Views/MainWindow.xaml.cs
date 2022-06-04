using System.Windows;
using Grammer.IssueTracking.Wpf.ViewModels;

namespace Grammer.IssueTracking.Wpf.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly BookWindow _bookWindow;

        public MainWindow(BookWindow bookWindow)
        {
            _bookWindow = bookWindow;

            InitializeComponent();
        }

        private void ButtonClicked(object sender, RoutedEventArgs e)
        {
            _bookWindow.Show();
        }
    }
}