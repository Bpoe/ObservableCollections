namespace Bpoe.Collections.Observable
{
    public class NotifyDictionaryItemRemovedEventArgs<TKey, TValue> : NotifyDictionaryChangedEventArgs<TKey, TValue>
    {
        /// <summary>
        /// Initializes a new instance of <see cref="NotifyDictionaryItemRemovedEventArgs" />.
        /// </summary>
        /// <param name="key">The key of the value that was removed.</param>
        public NotifyDictionaryItemRemovedEventArgs(TKey key)
            : base(NotifyDictionaryChangedAction.Remove)
        {
            this.Key = key;
        }

        /// <summary>
        /// The key of the value that was removed.
        /// </summary>
        public TKey Key { get; private set; }
    }
}
