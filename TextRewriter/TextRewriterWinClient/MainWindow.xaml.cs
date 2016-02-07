using System.Windows;
using System.Windows.Documents;
using TextRewriter.Rewriters;
using TextRewriter.Splitters;

namespace TextRewriterWinClient
{
    public partial class MainWindow : Window
    {
        private readonly TableRewriter tableRewriter;

        public MainWindow()
        {
            InitializeComponent();

            ITextSplitter columnSplitter = new NewLineSplitter();
            ITextSplitter rowSplitter = new TabSplitter();
            tableRewriter = new TableRewriter(columnSplitter, rowSplitter);
        }

        private void bRewrite_Click(object sender, RoutedEventArgs e)
        {
            string toRewrite = new TextRange(rtbToRewrite.Document.ContentStart, rtbToRewrite.Document.ContentEnd).Text;
            string result = tableRewriter.Rewrite(toRewrite);
            rtbRewritten.Document.Blocks.Clear();
            rtbRewritten.AppendText(result);
        }

        private void bPaste_Click(object sender, RoutedEventArgs e)
        {
            rtbToRewrite.Document.Blocks.Clear();
            rtbToRewrite.AppendText(Clipboard.GetText());
        }

        private void bCopy_Click(object sender, RoutedEventArgs e)
        {
            string rewritten = new TextRange(rtbRewritten.Document.ContentStart, rtbRewritten.Document.ContentEnd).Text;
            Clipboard.SetText(rewritten);
        }
    }
}
