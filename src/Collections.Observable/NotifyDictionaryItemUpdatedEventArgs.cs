namespace Bpoe.Collections.Observable
{
    public class NotifyDictionaryItemUpdatedEventArgs<TKey, TValue> : NotifyDictionaryChangedEventArgs<TKey, TValue>
    {
        /// <summary>
        /// Initializes a new instance of <see cref="NotifyDictionaryItemUpdatedEventArgs" />.
        /// </summary>
        /// <param name="key">The key of the value that was updated.</param>
        /// <param name="value">The new value.</param>
        public NotifyDictionaryItemUpdatedEventArgs(TKey key, TValue value)
            : base(NotifyDictionaryChangedAction.Update)
        {
            this.Key = key;
            this.Value = value;
        }

        /// <summary>
        /// The key of the value that was updated.
        /// </summary>
        public TKey Key { get; private set; }

        /// <summary>
        /// The new value.
        /// </summary>
        public TValue Value { get; private set; }
    }
}
