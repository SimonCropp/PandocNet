namespace PandocNet;

public class MultiMarkdownInput :
    InputOptions
{
    public MultiMarkdownInput(Stream stream) :
        base(stream)
    {
    }

    public MultiMarkdownInput(string file) :
        base(file)
    {
    }

    public override string Format => "markdown_mmd";
}