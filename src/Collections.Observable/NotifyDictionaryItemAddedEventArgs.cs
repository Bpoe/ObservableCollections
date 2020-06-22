namespace Bpoe.Collections.Observable
{
    public class NotifyDictionaryItemAddedEventArgs<TKey, TValue> : NotifyDictionaryChangedEventArgs<TKey, TValue>
    {
        /// <summary>
        /// Initializes a new instance of <see cref="NotifyDictionaryItemAddedEventArgs" />.
        /// </summary>
        /// <param name="key">The key of the value that was added.</param>
        /// <param name="value">The value.</param>
        public NotifyDictionaryItemAddedEventArgs(TKey key, TValue value)
            : base(NotifyDictionaryChangedAction.Add)
        {
            this.Key = key;
            this.Value = value;
        }

        /// <summary>
        /// The key of the value that was added.
        /// </summary>
        public TKey Key { get; private set; }

        /// <summary>
        /// The value.
        /// </summary>
        public TValue Value { get; private set; }
    }
}
