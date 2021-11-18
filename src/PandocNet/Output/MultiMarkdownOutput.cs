namespace PandocNet;

public class MultiMarkdownOutput :
    OutputOptions
{
    public MultiMarkdownOutput(Stream stream) :
        base(stream)
    {
    }

    public MultiMarkdownOutput(string file) :
        base(file)
    {
    }

    public override string Format => "markdown_mmd ";
}