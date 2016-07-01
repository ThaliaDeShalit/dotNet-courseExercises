using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericApp
{
    class MultiDictionary<K, V> : IMultiDictionary<K, V>, IEnumerable<KeyValuePair<K, V>>
    {
        private Dictionary<K, LinkedList<V>> _dictionary = new Dictionary<K, LinkedList<V>>();

        public void Add(K key, V value)
        {
            if (!_dictionary.ContainsKey(key))
            {
                _dictionary.Add(key, new LinkedList<V>());
            }

            _dictionary[key].AddLast(value);
        }

        public bool Remove(K key)
        {
            return _dictionary.Remove(key);
        }

        public bool Remove(K key, V value)
        {
            return _dictionary.ContainsKey(key) && _dictionary[key].Remove(value);
        }

        public void Clear()
        {
            _dictionary.Clear();
        }

        public bool ContainsKey(K key)
        {
            return _dictionary.ContainsKey(key);
        }

        public bool Contains(K key, V value)
        {
            return _dictionary.ContainsKey(key) && _dictionary[key].Contains(value);
        }

        public ICollection<K> Keys
        {
            get
            { 
                return _dictionary.Keys; 
            }
        }

        public ICollection<V> Values
        {
            get
            { 
                List<V> values = new List<V>();

                foreach (LinkedList<V> list in _dictionary.Values)
                {
                    foreach (V value in list)
                    {
                        values.Add(value);
                    }
                }

                return values;
            }
        }

        public int Count
        {
            get 
            {
                return Values.Count;
            }
        }

        public IEnumerator<KeyValuePair<K, V>> GetEnumerator()
        {
            List<KeyValuePair<K, V>> list = new List<KeyValuePair<K, V>>();

            foreach (K key in _dictionary.Keys)
            {
                foreach (V value in _dictionary[key])
                {
                    list.Add(new KeyValuePair<K, V>(key, value));
                }
            }

            return list.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
