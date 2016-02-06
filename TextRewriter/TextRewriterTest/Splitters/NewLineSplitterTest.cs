using NUnit.Framework;
using System;
using TextRewriter.Splitters;

namespace TextRewriterTest.Splitters
{
    [TestFixture]
    public class NewLineSplitterTest
    {
        [Test]
        public void Split_Null_NullReferenceException()
        {
            var target = new NewLineSplitter();
            Assert.Throws<NullReferenceException>(() => target.Split(null));
        }

        [Test]
        public void Split_NoNewLines_OneElementTable()
        {
            var target = new NewLineSplitter();
            var actual = target.Split("test");
            CollectionAssert.AreEqual(new[] { "test" }, actual);
        }

        [Test]
        public void Split_OneNewLine_TwoElementTable()
        {
            var target = new NewLineSplitter();
            var actual = target.Split("test1\r\ntest2");
            CollectionAssert.AreEqual(new[] { "test1", "test2" }, actual);
        }
    }
}
