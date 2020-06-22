namespace Bpoe.Collections.Observable.Tests
{
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ObservableDictionaryTests
    {
        private const string ExpectedKey = "anyKey";
        private const string ExpectedValue = "anyValue";

        [TestMethod]
        public void AddFiresEventWithNotifyDictionaryItemAddedEventArgs()
        {
            NotifyDictionaryChangedEventArgs<string, string> actualArgs = null;
            var dictionary = new ObservableDictionary<string, string>();
            dictionary.DictionaryChanged += (sender, args) => { actualArgs = args; };

            dictionary.Add(ExpectedKey, ExpectedValue);

            Assert.IsNotNull(actualArgs);
            Assert.AreEqual(NotifyDictionaryChangedAction.Add, actualArgs.Action);
            Assert.IsInstanceOfType(actualArgs, typeof(NotifyDictionaryItemAddedEventArgs<string, string>));

            var addedArgs = (NotifyDictionaryItemAddedEventArgs<string, string>)actualArgs;
            Assert.AreEqual(ExpectedKey, addedArgs.Key);
            Assert.AreEqual(ExpectedValue, addedArgs.Value);
        }

        [TestMethod]
        public void AddFiresEventWithNotifyDictionaryItemUpdatedEventArgs()
        {
            NotifyDictionaryChangedEventArgs<string, string> actualArgs = null;
            var dictionary = new ObservableDictionary<string, string>
            {
                { ExpectedKey, "originalValue" }
            };
            dictionary.DictionaryChanged += (sender, args) => { actualArgs = args; };

            dictionary[ExpectedKey] = ExpectedValue;

            Assert.IsNotNull(actualArgs);
            Assert.AreEqual(NotifyDictionaryChangedAction.Update, actualArgs.Action);
            Assert.IsInstanceOfType(actualArgs, typeof(NotifyDictionaryItemUpdatedEventArgs<string, string>));

            var updatedArgs = (NotifyDictionaryItemUpdatedEventArgs<string, string>)actualArgs;
            Assert.AreEqual(ExpectedKey, updatedArgs.Key);
            Assert.AreEqual(ExpectedValue, updatedArgs.Value);
        }

        [TestMethod]
        public void AddFiresEventWithNotifyDictionaryItemRemovedEventArgs()
        {
            NotifyDictionaryChangedEventArgs<string, string> actualArgs = null;
            var dictionary = new ObservableDictionary<string, string>
            {
                { ExpectedKey, "originalValue" }
            };
            dictionary.DictionaryChanged += (sender, args) => { actualArgs = args; };

            dictionary.Remove(ExpectedKey);

            Assert.IsNotNull(actualArgs);
            Assert.AreEqual(NotifyDictionaryChangedAction.Remove, actualArgs.Action);
            Assert.IsInstanceOfType(actualArgs, typeof(NotifyDictionaryItemRemovedEventArgs<string, string>));

            var removedArgs = (NotifyDictionaryItemRemovedEventArgs<string, string>)actualArgs;
            Assert.AreEqual(ExpectedKey, removedArgs.Key);
        }

        [TestMethod]
        public void AddFiresEventWithNotifyDictionaryItemClearedEventArgs()
        {
            NotifyDictionaryChangedEventArgs<string, string> actualArgs = null;
            var dictionary = new ObservableDictionary<string, string>
            {
                { ExpectedKey, "originalValue" }
            };
            dictionary.DictionaryChanged += (sender, args) => { actualArgs = args; };

            dictionary.Clear();

            Assert.IsNotNull(actualArgs);
            Assert.AreEqual(NotifyDictionaryChangedAction.Clear, actualArgs.Action);
            Assert.IsInstanceOfType(actualArgs, typeof(NotifyDictionaryItemClearedEventArgs<string, string>));
            Assert.AreEqual(0, dictionary.Count);
        }
    }
}
