namespace PandocNet;

public class PandocMarkdownInput :
    InputOptions
{
    public PandocMarkdownInput(Stream stream) :
        base(stream)
    {
    }

    public PandocMarkdownInput(string file) :
        base(file)
    {
    }

    public override string Format => "markdown";
}