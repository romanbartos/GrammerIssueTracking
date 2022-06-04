using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Grammer.IssueTracking.Core.Models
{
    public class Kniha : INotifyPropertyChanged
    {
        private int knihaId { get; set; }
        private int idOddeleni { get; set; }
        
        public int KnihaId
        {
            get => knihaId;
            set
            {
                knihaId = value;
                OnPropertyChanged(nameof(KnihaId));
            }
        }

        public int IdOddeleni
        {
            get => idOddeleni;
            set
            {
                idOddeleni = value;
                OnPropertyChanged(nameof(IdOddeleni));
            }
        }
        
        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}
