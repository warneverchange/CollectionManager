using CollectionManager.core.entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionManager.viewmodel.input_page_view_model
{
    public class WorkerViewModel : INotifyPropertyChanged
    {
        private Worker _currentWorker;

        public Worker CurrentWorker
        {
            get => _currentWorker;
            set
            {
                _currentWorker = value;
                OnPropertyChanged(nameof(CurrentWorker));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public WorkerViewModel(Worker worker)
        {
            CurrentWorker = worker;
        }
        public void OnPropertyChanged(string changedProperty)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(changedProperty));
        }

        public string FirstName
        {
            get => _currentWorker.FirstName;
            set
            {
                _currentWorker.FirstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }

        public string LastName
        {
            get => _currentWorker.LastName;
            set
            {
                _currentWorker.LastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }

        public string PhoneNumber
        {
            get => _currentWorker.PhoneNumber;
            set
            {
                _currentWorker.PhoneNumber = value;
                OnPropertyChanged(nameof(PhoneNumber));
            }
        }
    }
}
