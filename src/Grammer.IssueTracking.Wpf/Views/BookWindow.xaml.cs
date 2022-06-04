using System;
using System.Windows;
using Grammer.IssueTracking.Wpf.ViewModels;
using Microsoft.Extensions.Logging;

namespace Grammer.IssueTracking.Wpf.Views
{
    public partial class BookWindow : Window
    {
        private readonly ILogger<BookWindow> _logger;
        private readonly KnihaViewModel _knihaViewModel;

        public BookWindow(ILogger<BookWindow> logger, KnihaViewModel knihaViewModel)
        {
            _logger = logger;
            _knihaViewModel = knihaViewModel;
            
            InitializeComponent();
            ProvisionDataContext();
        }

        private void ProvisionDataContext()
        {
            try
            {
                DataContext = _knihaViewModel.Books;
            }
            catch (Exception)
            {
                _logger.LogWarning("Could not retrieve Books from ViewModel");
            }
        }
    }
}