using System.Windows;

namespace Grammer.IssueTracking.Wpf.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly BookWindowFactory _bookWindowFactory;

        public MainWindow(BookWindowFactory bookWindowFactory)
        {
            _bookWindowFactory = bookWindowFactory;

            InitializeComponent();
        }

        private void ButtonClicked(object sender, RoutedEventArgs e)
        {
            _bookWindowFactory.Open();
        }
    }
}