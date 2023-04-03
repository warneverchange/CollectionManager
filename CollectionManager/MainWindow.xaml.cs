using CollectionManager.core.entities;
using CollectionManager.core.logic.deserializers;
using CollectionManager.core.logic.save_restore;
using CollectionManager.core.logic.save_restore.save;
using CollectionManager.core.logic.save_restore.saver;
using CollectionManager.core.logic.serializers;
using CollectionManager.core.logic.serializers.interfaces;
using CollectionManager.viewmodel;
using CollectionManager.viewmodel.main_page_viewmodels.components_viewmodels;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace CollectionManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ApplicationViewModel ApplicationViewModel { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            Dictionary<string, ISerializer<Dictionary<string, ICollection<Worker>>>> serializers
                = new Dictionary<string, ISerializer<Dictionary<string, ICollection<Worker>>>>()
            {
                {"Json", new JSONSerializer<Dictionary<string, ICollection<Worker>>>() },
                {"Xml", new XMLDictSerializer() },
                {"Binary", new BinarySerializer<Dictionary<string, ICollection<Worker>>>(new BinaryFormatter()) }
            };

            DictionaryViewModel dictViewModel =
                new DictionaryViewModel(
                    new Dictionary<string, ICollection<Worker>>()
                    {
                        {"key1", new List<Worker>() {new Worker("Konstantin", "Chechkin", "89963250540  "), new Worker("Luzina", "Anna", "89292320161")} }
                    });

            var dataSaver = new DataSaverViewModel(
                serializers,
                new KeyValuePair<string, ISerializer<Dictionary<string, ICollection<Worker>>>>("Json", serializers["Json"]),
                (Dictionary<string, ICollection<Worker>>)dictViewModel.Dictionary,
                new DictDataSaver<Dictionary<string, ICollection<Worker>>>()
                );
            ApplicationViewModel = new ApplicationViewModel(
                dictViewModel,
                new DataRestorerViewModel(dictViewModel, new DictionaryDeserializerFactory(), new DictDataRestorer<Dictionary<string, ICollection<Worker>>>()),
                dataSaver,
                this);

            DataContext = ApplicationViewModel;
        }
    }
}
