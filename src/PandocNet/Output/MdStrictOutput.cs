namespace PandocNet;

public class MdStrictOutput :
    OutputOptions
{
    public MdStrictOutput(Stream stream) :
        base(stream)
    {
    }

    public MdStrictOutput(string file) :
        base(file)
    {
    }

    public override string Format => "markdown_strict";
}