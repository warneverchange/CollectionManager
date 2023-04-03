using CollectionManager.core.entities;
using CollectionManager.core.logic.deserializers.interfaces;
using CollectionManager.core.logic.save_restore.save;
using CollectionManager.fkfutures;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CollectionManager.viewmodel.main_page_viewmodels.components_viewmodels
{
    public class DataRestorerViewModel
    {
        private DictionaryViewModel _dictViewModel;
        private static IDeserializerFactory<Dictionary<string, ICollection<Worker>>> _deserializerFactory;
        private IDataRestorer<Dictionary<string, ICollection<Worker>>> _dataRestorer;

        public DataRestorerViewModel(
            DictionaryViewModel dictViewModel,
            IDeserializerFactory<Dictionary<string, ICollection<Worker>>> deserializerFactory,
            IDataRestorer<Dictionary<string, ICollection<Worker>>> dataRestorer)
        {
            _dictViewModel = dictViewModel;
            _deserializerFactory = deserializerFactory;
            _dataRestorer = dataRestorer;
        }

        public ICommand RestoreData => new ActionCommand(() =>
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            string selectedPath = openFileDialog.FileName;
            try
            {
                _dictViewModel.Dictionary = _dataRestorer.Restore(_deserializerFactory, selectedPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        });
    }
}
