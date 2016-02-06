using NUnit.Framework;
using System.Collections;
using TextRewriter.Rewriters;
using TextRewriter.Splitters;
using TextRewriterTest.Properties;

namespace TextRewriterTest.Rewriters
{
    [TestFixture]
    public class TableRewriterTest
    {
        [Test, TestCaseSource(typeof(TableRewriterTestCasesFactory), nameof(TableRewriterTestCasesFactory.TestCases))]
        public string RewriteTest(string text)
        {
            ITextSplitter rowSplitter = new NewLineSplitter();
            ITextSplitter columnSplitter = new TabSplitter();
            ITextRewriter target = new TableRewriter(rowSplitter, columnSplitter);
            return target.Rewrite(text);
        }
    }

    public class TableRewriterTestCasesFactory
    {
        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData(Resources.TableRewriterTest1Text).Returns(Resources.TableRewriterTest1Expected);
                yield return new TestCaseData(Resources.TableRewriterTest2Text).Returns(Resources.TableRewriterTest2Expected);
            }
        }
    }
}
