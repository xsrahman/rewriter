using System.Text;
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
            StringBuilder builder = new StringBuilder();
            string[] rows = rowSplitter.Split(text);

            if (rows.Length == 0)
            {
                return null;
            }

            string[] columnsHeader = columnSplitter.Split(rows[0]);
            for (int i = 1; i < rows.Length; i++)
            {
                string[] columns = columnSplitter.Split(rows[i]);
                for (int j = 0; j < columns.Length && j < columnsHeader.Length; j++)
                {
                    builder.AppendLine($"{columnsHeader[j].Trim()}: {columns[j]}");
                }
            }

            return builder.ToString();
        }
    }
}
