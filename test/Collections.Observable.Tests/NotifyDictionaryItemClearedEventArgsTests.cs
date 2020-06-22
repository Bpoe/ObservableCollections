namespace Bpoe.Collections.Observable.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class NotifyDictionaryItemClearedEventArgsTests
    {
        [TestMethod]
        public void ConstructorSetsActionToClear()
        {
            var args = new NotifyDictionaryItemClearedEventArgs<string, string>();
            Assert.AreEqual(NotifyDictionaryChangedAction.Clear, args.Action);
        }
    }
}
