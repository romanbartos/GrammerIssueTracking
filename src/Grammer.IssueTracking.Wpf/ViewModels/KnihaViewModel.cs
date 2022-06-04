using System;
using System.Collections.Generic;
using System.Windows.Input;
using Grammer.IssueTracking.Core.Models;
using Grammer.IssueTracking.Core.Repositories;
using Microsoft.Extensions.Logging;

namespace Grammer.IssueTracking.Wpf.ViewModels
{
    public class KnihaViewModel
    {
        private readonly ILogger<KnihaViewModel> _logger;
        private readonly KnihaRepository _knihaRepository;
        private IList<Kniha> _booksList;

        public KnihaViewModel(ILogger<KnihaViewModel> logger, KnihaRepository knihaRepository)
        {
            _logger = logger;
            _knihaRepository = knihaRepository;

            try
            {
                _booksList = (IList<Kniha>)_knihaRepository.GetAll();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Cannot get items from Book repository");
            }
        }

        public IList<Kniha> Books
        {
            get => _booksList;
            set => _booksList = value;
        }

        private ICommand mUpdater;

        public ICommand UpdateCommand
        {
            get => mUpdater ??= new Updater();
            set => mUpdater = value;
        }

        private class Updater : ICommand
        {
            #region ICommand Members

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter)
            {
            }

            #endregion
        }
    }
}