using CollectionManager.core.entities;
using CollectionManager.fkfutures;
using CollectionManager.viewmodel.main_page_viewmodels.components_viewmodels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CollectionManager.viewmodel.input_page_view_model
{
    public class InputPageViewModel : INotifyPropertyChanged
    {
        private Window _connectingWindow;
        private WorkerViewModel _workerViewModel;
        public event PropertyChangedEventHandler? PropertyChanged;
        public WorkerViewModel WorkerViewModel
        {
            get => _workerViewModel;
            set
            {
                _workerViewModel = value;
                OnPropertyChanged(nameof(WorkerViewModel));
            }
        }

        public void OnPropertyChanged(string changedProperty)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(changedProperty));
        }


        public InputPageViewModel(WorkerViewModel workerViewModel, Window connectingWindow)
        {
            _connectingWindow = connectingWindow;
            WorkerViewModel = workerViewModel;
        }

        private void SaveWorkerData(DictionaryViewModel dictionaryViewModel, string key)
        {
            if (dictionaryViewModel.ContainsKey(key))
            {
                dictionaryViewModel[key].Add(WorkerViewModel.CurrentWorker);
            }
            else
            {
                var value = new LinkedList<Worker>();
                value.AddLast(WorkerViewModel.CurrentWorker);
                dictionaryViewModel.Add(key, value);
            }
        }

        public ICommand SaveWorkerDataCommand => new ActionCommand(() =>
        {
            Window windowOwner = _connectingWindow.Owner;
            if (windowOwner is MainWindow mainWindow)
            {
                SaveWorkerData(
                    mainWindow.ApplicationViewModel.DictionaryViewModel,
                    mainWindow.ApplicationViewModel.DictionaryViewModel.CurrentKey);
            }
            ExitCommand.Execute(null);
        });

        public ICommand ExitCommand => new ActionCommand(() =>
        {
            _connectingWindow.Close();
        });
    }
}
