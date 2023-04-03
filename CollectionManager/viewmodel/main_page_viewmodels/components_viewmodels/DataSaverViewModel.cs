using CollectionManager.core.entities;
using CollectionManager.core.logic.save_restore.saver;
using CollectionManager.core.logic.serializers.interfaces;
using CollectionManager.fkfutures;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CollectionManager.viewmodel.main_page_viewmodels.components_viewmodels
{
    public class DataSaverViewModel : INotifyPropertyChanged
    {
        private KeyValuePair<string, ISerializer<Dictionary<string, ICollection<Worker>>>> _selectedSerializer;
        private Dictionary<string, ICollection<Worker>> _observeredObject;
        private IDataSaver<Dictionary<string, ICollection<Worker>>> _dataSaver;

        public event PropertyChangedEventHandler? PropertyChanged;

        public Dictionary<string, ISerializer<Dictionary<string, ICollection<Worker>>>> Serializers { get; set; }
        public KeyValuePair<string, ISerializer<Dictionary<string, ICollection<Worker>>>> SelectedSerializer
        {
            get => _selectedSerializer;
            set
            {
                _selectedSerializer = value;
                OnPropertyChanged(nameof(SelectedSerializer));
            }
        }


        public void OnPropertyChanged(string changedProperty)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(changedProperty));
        }

        public DataSaverViewModel(
            Dictionary<string, ISerializer<Dictionary<string, ICollection<Worker>>>> serializers,
            KeyValuePair<string, ISerializer<Dictionary<string, ICollection<Worker>>>> selectedSerializer,
            Dictionary<string, ICollection<Worker>> observeredObject,
            IDataSaver<Dictionary<string, ICollection<Worker>>> dataSaver)
        {
            Serializers = serializers;
            SelectedSerializer = selectedSerializer;
            _observeredObject = observeredObject;
            _dataSaver = dataSaver;
        }

        public ICommand SerializeCommand => new ActionCommand(() =>
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.ShowDialog();
            string selectedPath = saveFileDialog.FileName;
            try
            {
                _dataSaver.Save(SelectedSerializer.Value, selectedPath, _observeredObject);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        });
    }
}
