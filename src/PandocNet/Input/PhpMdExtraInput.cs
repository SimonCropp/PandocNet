namespace PandocNet;

public class PhpMdExtraInput :
    BaseMdInput
{
    public PhpMdExtraInput(Stream stream) :
        base(stream)
    {
    }

    public PhpMdExtraInput(string file) :
        base(file)
    {
    }

    public override string Format => "markdown_phpextra";
}