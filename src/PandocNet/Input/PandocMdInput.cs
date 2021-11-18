namespace PandocNet;

public class PandocMdInput :
    BaseMdInput
{
    public PandocMdInput(Stream stream) :
        base(stream)
    {
    }

    public PandocMdInput(string file) :
        base(file)
    {
    }

    public override string Format => "markdown";
}