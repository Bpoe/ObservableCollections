namespace Bpoe.Collections.Observable
{
    using System;

    public abstract class NotifyDictionaryChangedEventArgs<TKey, TValue> : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of <see cref="NotifyDictionaryChangedEventArgs" />.
        /// </summary>
        /// <param name="action"></param>
        public NotifyDictionaryChangedEventArgs(NotifyDictionaryChangedAction action)
        {
            this.Action = action;
        }

        public NotifyDictionaryChangedAction Action { get; private set; }
    }
}
