using System.Windows;
using Grammer.IssueTracking.Core;
using Grammer.IssueTracking.Core.Interfaces;
using Grammer.IssueTracking.Wpf.ViewModels;
using Microsoft.Extensions.Logging;

namespace Grammer.IssueTracking.Wpf.Views
{
    public partial class BookWindow : Window
    {
        private readonly ILogger<BookWindow> _logger;

        public BookWindow(ILogger<BookWindow> logger)
        {
            _logger = logger;
            InitializeComponent();
        }
    }

    public class BookWindowFactory : IWindowFactory
    {
        private readonly ILogger<BookWindow> logger;
        private readonly KnihaViewModel knihaViewModel;

        public BookWindowFactory(ILogger<BookWindow> logger, KnihaViewModel knihaViewModel)
        {
            this.logger = logger;
            this.knihaViewModel = knihaViewModel;
        }

        public void Open()
        {
            var view = new BookWindow(logger)
            {
                //Bind
                DataContext = knihaViewModel
            };

            view.Show();
        }
    }
}