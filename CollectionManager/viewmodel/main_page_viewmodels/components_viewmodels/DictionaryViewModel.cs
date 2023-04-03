using CollectionManager.core.entities;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace CollectionManager.viewmodel.main_page_viewmodels.components_viewmodels
{
    public class DictionaryViewModel : INotifyPropertyChanged, IEnumerable<KeyValuePair<string, ICollection<Worker>>>
    {
        private IDictionary<string, ICollection<Worker>> _data;
        public event PropertyChangedEventHandler? PropertyChanged;

        private string _currentKey;

        public string CurrentKey
        {
            get => _currentKey;
            set
            {
                _currentKey = value;
                OnProperyChanged(nameof(CurrentKey));
                OnProperyChanged(nameof(Data));
            }
        }

        public IEnumerable<Worker> AllWorkers => this
            .SelectMany(x => x.Value);

        public IDictionary<string, ICollection<Worker>> Dictionary
        {
            get => _data;
            set
            {
                _data = value;
                OnProperyChanged("Data");
            }
        }


        public IEnumerable<Worker> Data
        {
            get
            {
                if (CurrentKey.Equals(""))
                {
                    return AllWorkers;
                }
                else
                {
                    if (ContainsKey(CurrentKey))
                    {
                        return this[CurrentKey];
                    }
                    else
                    {
                        return Enumerable.Empty<Worker>();
                    }
                }
            }
        }


        public ICollection<Worker> this[string key]
        {
            get => Dictionary[key];
            set
            {
                Dictionary[key] = value;
                OnProperyChanged("Data");

            }
        }

        public ICollection<string> Keys => Dictionary.Keys;
        public ICollection<ICollection<Worker>> Values => Dictionary.Values;


        public void Add(string key, ICollection<Worker> value)
        {
            Dictionary.Add(key, value);
            OnProperyChanged("Data");
        }

        public bool ContainsKey(string key)
        {
            return Dictionary.ContainsKey(key);
        }

        public bool Remove(string key)
        {
            bool result = Dictionary.Remove(key);
            OnProperyChanged("Data");
            return result;
        }

        public bool TryGeICollection(string key, [MaybeNullWhen(false)] out ICollection<Worker> value)
        {
            return Dictionary.TryGetValue(key, out value);
        }


        public DictionaryViewModel(IDictionary<string, ICollection<Worker>> data)
        {
            _data = data;
            _currentKey = "";
        }

        private void OnProperyChanged(string changedProperty)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(changedProperty));
        }

        public IEnumerator<KeyValuePair<string, ICollection<Worker>>> GetEnumerator()
        {
            return Dictionary.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
