namespace PandocNet;

public class GhMarkdownOutput :
    OutputOptions
{
    public GhMarkdownOutput(Stream stream) :
        base(stream)
    {
    }

    public GhMarkdownOutput(string file) :
        base(file)
    {
    }

    public override string Format => "gfm";
}