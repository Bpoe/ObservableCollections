namespace Bpoe.Collections.Observable.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class NotifyDictionaryItemUpdatedEventArgsTests
    {
        private const string ExpectedKey = "anyKey";
        private const string ExpectedValue = "anyValue";

        [TestMethod]
        public void ConstructorSetsActionToUpdate()
        {
            var args = new NotifyDictionaryItemUpdatedEventArgs<string, string>(ExpectedKey, ExpectedValue);
            Assert.AreEqual(NotifyDictionaryChangedAction.Update, args.Action);
        }

        [TestMethod]
        public void ConstructorSetsKey()
        {
            var args = new NotifyDictionaryItemUpdatedEventArgs<string, string>(ExpectedKey, ExpectedValue);
            Assert.AreEqual(ExpectedKey, args.Key);
        }

        [TestMethod]
        public void ConstructorSetsValue()
        {
            var args = new NotifyDictionaryItemUpdatedEventArgs<string, string>(ExpectedKey, ExpectedValue);
            Assert.AreEqual(ExpectedValue, args.Value);
        }
    }
}
