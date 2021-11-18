namespace PandocNet;

public class PandocMarkdownOutput :
    OutputOptions
{
    public PandocMarkdownOutput(Stream stream) :
        base(stream)
    {
    }

    public PandocMarkdownOutput(string file) :
        base(file)
    {
    }

    public override string Format => "markdown";
}