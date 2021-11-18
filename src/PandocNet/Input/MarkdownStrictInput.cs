namespace PandocNet;

public class MarkdownStrictInput :
    InputOptions
{
    public MarkdownStrictInput(Stream stream) :
        base(stream)
    {
    }

    public MarkdownStrictInput(string file) :
        base(file)
    {
    }

    public override string Format => "markdown_strict";
}