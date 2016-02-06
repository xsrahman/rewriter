namespace TextRewriter.Splitters
{
    public interface ITextSplitter
    {
        string[] Split(string text);
    }
}
