namespace Bpoe.Collections.Observable.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class NotifyDictionaryItemRemovedEventArgsTests
    {
        private const string ExpectedKey = "anyKey";

        [TestMethod]
        public void ConstructorSetsActionToRemove()
        {
            var args = new NotifyDictionaryItemRemovedEventArgs<string, string>(ExpectedKey);
            Assert.AreEqual(NotifyDictionaryChangedAction.Remove, args.Action);
        }

        [TestMethod]
        public void ConstructorSetsKey()
        {
            var args = new NotifyDictionaryItemRemovedEventArgs<string, string>(ExpectedKey);
            Assert.AreEqual(ExpectedKey, args.Key);
        }
    }
}
