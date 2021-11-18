namespace PandocNet;

public class GhMdInput :
    BaseMdInput
{
    public GhMdInput(Stream stream) :
        base(stream)
    {
    }

    public GhMdInput(string file) :
        base(file)
    {
    }

    public override string Format => "gfm";
}