namespace Bpoe.Collections.Observable
{
    public class NotifyDictionaryItemClearedEventArgs<TKey, TValue> : NotifyDictionaryChangedEventArgs<TKey, TValue>
    {
        /// <summary>
        /// Initializes a new instance of <see cref="NotifyDictionaryItemClearedEventArgs" />.
        /// </summary>
        public NotifyDictionaryItemClearedEventArgs()
            : base(NotifyDictionaryChangedAction.Clear)
        {
        }
    }
}
