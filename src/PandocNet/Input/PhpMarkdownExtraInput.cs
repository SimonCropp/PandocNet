namespace PandocNet;

public class PhpMarkdownExtraInput :
    InputOptions
{
    public PhpMarkdownExtraInput(Stream stream) :
        base(stream)
    {
    }

    public PhpMarkdownExtraInput(string file) :
        base(file)
    {
    }

    public override string Format => "markdown_phpextra";
}