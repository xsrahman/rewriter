using System;

namespace TextRewriter.Splitters
{
    public class NewLineSplitter : ITextSplitter
    {
        public string[] Split(string text)
        {
            return text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
        }
    }
}
