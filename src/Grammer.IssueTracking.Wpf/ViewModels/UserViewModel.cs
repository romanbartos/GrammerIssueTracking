using System;
using System.Collections.Generic;
using System.Windows.Input;
using Grammer.IssueTracking.Core.Models;

namespace Grammer.IssueTracking.Wpf.ViewModels
{
    internal class UserViewModel
    {
        private IList<User> _usersList;

        public UserViewModel()
        {
            _usersList = new List<User>
            {
                new()
                {
                    UserId = 1, FirstName = "Raj", LastName = "Beniwal", City = "Delhi", State = "DEL",
                    Country = "INDIA"
                },
                new()
                {
                    UserId = 2, FirstName = "Mark", LastName = "henry", City = "New York", State = "NY", Country = "USA"
                },
                new()
                {
                    UserId = 3, FirstName = "Mahesh", LastName = "Chand", City = "Philadelphia", State = "PHL",
                    Country = "USA"
                },
                new()
                {
                    UserId = 4, FirstName = "Vikash", LastName = "Nanda", City = "Noida", State = "UP",
                    Country = "INDIA"
                },
                new()
                {
                    UserId = 5, FirstName = "Harsh", LastName = "Kumar", City = "Ghaziabad", State = "UP",
                    Country = "INDIA"
                },
                new()
                {
                    UserId = 6, FirstName = "Reetesh", LastName = "Tomar", City = "Mumbai", State = "MP",
                    Country = "INDIA"
                },
                new()
                {
                    UserId = 7, FirstName = "Deven", LastName = "Verma", City = "Palwal", State = "HP",
                    Country = "INDIA"
                },
                new()
                {
                    UserId = 8, FirstName = "Ravi", LastName = "Taneja", City = "Delhi", State = "DEL",
                    Country = "INDIA"
                }
            };
        }

        public IList<User> Users
        {
            get => _usersList;
            set => _usersList = value;
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