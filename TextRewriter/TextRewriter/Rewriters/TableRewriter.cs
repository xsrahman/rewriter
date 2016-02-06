using System;
using TextRewriter.Splitters;

namespace TextRewriter.Rewriters
{
    public class TableRewriter : ITextRewriter
    {
        private readonly ITextSplitter rowSplitter;
        private readonly ITextSplitter columnSplitter;

        public TableRewriter(ITextSplitter rowSplitter, ITextSplitter columnSplitter)
        {
            this.rowSplitter = rowSplitter;
            this.columnSplitter = columnSplitter;
        }

        public string Rewrite(string text)
        {
            throw new NotImplementedException();
        }
    }
}
