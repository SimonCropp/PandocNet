namespace PandocNet;

public class PhpMdExtraOutput :
    OutputOptions
{
    public PhpMdExtraOutput(Stream stream) :
        base(stream)
    {
    }

    public PhpMdExtraOutput(string file) :
        base(file)
    {
    }

    public override string Format => "markdown_phpextra";
}