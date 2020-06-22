namespace Bpoe.Collections.Observable
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ObservableDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        private readonly IDictionary<TKey, TValue> dictionary;

        /// <summary>
        /// Initializes a new instance of <see cref="ObservableDictionary"/>.
        /// </summary>
        public ObservableDictionary()
        {
            this.dictionary = new Dictionary<TKey, TValue>();
        }

        /// <summary>
        /// Initializes a new instance of <see cref="ObservableDictionary"/>.
        /// </summary>
        public ObservableDictionary(IDictionary<TKey, TValue> dictionary)
        {
            this.dictionary = new Dictionary<TKey, TValue>(dictionary);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="ObservableDictionary"/>.
        /// </summary>
        public ObservableDictionary(IEqualityComparer<TKey> comparer)
        {
            this.dictionary = new Dictionary<TKey, TValue>(comparer);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="ObservableDictionary"/>.
        /// </summary>
        public ObservableDictionary(int capacity)
        {
            this.dictionary = new Dictionary<TKey, TValue>(capacity);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="ObservableDictionary"/>.
        /// </summary>
        public ObservableDictionary(IDictionary<TKey, TValue> dictionary, IEqualityComparer<TKey> comparer)
        {
            this.dictionary = new Dictionary<TKey, TValue>(dictionary, comparer);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="ObservableDictionary"/>.
        /// </summary>
        public ObservableDictionary(int capacity, IEqualityComparer<TKey> comparer)
        {
            this.dictionary = new Dictionary<TKey, TValue>(capacity, comparer);
        }

        public event EventHandler<NotifyDictionaryChangedEventArgs<TKey, TValue>> DictionaryChanged;

        public TValue this[TKey key]
        {
            get
            {
                return this.dictionary[key];
            }

            set
            {
                this.dictionary[key] = value;
                this.OnDictionaryChanged(new NotifyDictionaryItemUpdatedEventArgs<TKey, TValue>(key, value));
            }
        }

        public ICollection<TKey> Keys => this.dictionary.Keys;

        public ICollection<TValue> Values => this.dictionary.Values;

        public int Count => this.dictionary.Count;

        public bool IsReadOnly => this.dictionary.IsReadOnly;

        public void Add(TKey key, TValue value)
        {
            this.dictionary.Add(key, value);

            this.OnDictionaryChanged(new NotifyDictionaryItemAddedEventArgs<TKey, TValue>(key, value));
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            this.dictionary.Add(item);

            this.OnDictionaryChanged(new NotifyDictionaryItemAddedEventArgs<TKey, TValue>(item.Key, item.Value));
        }

        public void Clear()
        {
            this.dictionary.Clear();

            this.OnDictionaryChanged(new NotifyDictionaryItemClearedEventArgs<TKey, TValue>());
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return this.dictionary.Contains(item);
        }

        public bool ContainsKey(TKey key)
        {
            return this.dictionary.ContainsKey(key);
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            this.dictionary.CopyTo(array, arrayIndex);
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return this.dictionary.GetEnumerator();
        }

        public bool Remove(TKey key)
        {
            var result = this.dictionary.Remove(key);

            this.OnDictionaryChanged(new NotifyDictionaryItemRemovedEventArgs<TKey, TValue>(key));
            return result;
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            var result = this.dictionary.Remove(item);

            this.OnDictionaryChanged(new NotifyDictionaryItemRemovedEventArgs<TKey, TValue>(item.Key));
            return result;
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            return this.dictionary.TryGetValue(key, out value);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.dictionary.GetEnumerator();
        }

        private void OnDictionaryChanged(NotifyDictionaryChangedEventArgs<TKey, TValue> eventArgs)
        {
            this.DictionaryChanged?.Invoke(this, eventArgs);
        }
    }
}
