using NUnit.Framework;
using System;
using TextRewriter.Splitters;

namespace TextRewriterTest.Splitters
{
    [TestFixture]
    public class TabSplitterTest
    {
        [Test]
        public void Split_Null_NullReferenceException()
        {
            var target = new TabSplitter();
            Assert.Throws<NullReferenceException>(() => target.Split(null));
        }

        [Test]
        public void Split_NoTabs_OneElementTable()
        {
            var target = new TabSplitter();
            var actual = target.Split("test");
            CollectionAssert.AreEqual(new[] { "test" }, actual);
        }

        [Test]
        public void Split_OneTab_TwoElementTable()
        {
            var target = new TabSplitter();
            var actual = target.Split("test1\ttest2");
            CollectionAssert.AreEqual(new[] { "test1", "test2" }, actual);
        }
    }
}
