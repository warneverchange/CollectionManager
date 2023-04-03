using CollectionManager.fkfutures;
using CollectionManager.viewmodel.main_page_viewmodels.components_viewmodels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CollectionManager.viewmodel
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        public DataRestorerViewModel DataRestorerViewModel { get; set; }
        public DataSaverViewModel DataSaverViewModel { get; set; }
        private DictionaryViewModel _dictionary;


        public event PropertyChangedEventHandler? PropertyChanged;
        private Window _connectingWindow;


        public DictionaryViewModel DictionaryViewModel
        {
            get => _dictionary;
            set
            {
                _dictionary = value;
                OnProperyChanged(this, new PropertyChangedEventArgs(nameof(DictionaryViewModel)));
            }
        }

        
        public ICommand RemoveCollectionWithKeys => new ActionCommandWithParam<string>((key) =>
        {
            bool isCommandSuccessfull = _dictionary.Remove(key);
            if (!isCommandSuccessfull)
            {
                MessageBox.Show("Element with such key isn't finded");
            }
        });

        public ICommand AddNewWorkerByKey => new ActionCommandWithParam<string>((key) =>
        {
            if (!DictionaryViewModel.CurrentKey.Equals(""))
            {
                InputPage inputPage = new InputPage();
                inputPage.Owner = _connectingWindow;
                inputPage.Show();
            } else
            {
                MessageBox.Show("You can not add user with empty key");
            }

        });

        public ApplicationViewModel(
            DictionaryViewModel dictionary,
            DataRestorerViewModel restorer,
            DataSaverViewModel saver,
            Window connectingWindow)
        {
            DictionaryViewModel = dictionary;
            DataRestorerViewModel = restorer;
            DataSaverViewModel = saver;
            _connectingWindow = connectingWindow;
        }


        public void OnProperyChanged(object sender, PropertyChangedEventArgs eventArgs)
        {
            PropertyChanged?.Invoke(this, eventArgs);
        }
    }
}
