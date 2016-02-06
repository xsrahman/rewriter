namespace TextRewriter.Splitters
{
    public class TabSplitter : ITextSplitter
    {
        private const char Tab = '\t';

        public string[] Split(string text)
        {
            return text.Split(Tab);
        }
    }
}
