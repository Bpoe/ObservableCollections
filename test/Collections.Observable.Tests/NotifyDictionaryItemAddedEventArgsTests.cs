namespace Bpoe.Collections.Observable.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class NotifyDictionaryItemAddedEventArgsTests
    {
        private const string ExpectedKey = "anyKey";
        private const string ExpectedValue = "anyValue";

        [TestMethod]
        public void ConstructorSetsActionToAdd()
        {
            var args = new NotifyDictionaryItemAddedEventArgs<string, string>(ExpectedKey, ExpectedValue);
            Assert.AreEqual(NotifyDictionaryChangedAction.Add, args.Action);
        }

        [TestMethod]
        public void ConstructorSetsKey()
        {
            var args = new NotifyDictionaryItemAddedEventArgs<string, string>(ExpectedKey, ExpectedValue);
            Assert.AreEqual(ExpectedKey, args.Key);
        }

        [TestMethod]
        public void ConstructorSetsValue()
        {
            var args = new NotifyDictionaryItemAddedEventArgs<string, string>(ExpectedKey, ExpectedValue);
            Assert.AreEqual(ExpectedValue, args.Value);
        }
    }
}
