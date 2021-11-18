namespace PandocNet;

public class GhMarkdownInput :
    InputOptions
{
    public GhMarkdownInput(Stream stream) :
        base(stream)
    {
    }

    public GhMarkdownInput(string file) :
        base(file)
    {
    }

    public override string Format => "gfm";
}