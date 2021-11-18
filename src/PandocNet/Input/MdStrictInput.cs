namespace PandocNet;

public class MdStrictInput :
    BaseMdInput
{
    public MdStrictInput(Stream stream) :
        base(stream)
    {
    }

    public MdStrictInput(string file) :
        base(file)
    {
    }

    public override string Format => "markdown_strict";
}