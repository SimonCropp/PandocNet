namespace PandocNet;

public class RstIn :
    InOptions
{
    public RstIn(Stream stream) :
        base(stream)
    {
    }

    public RstIn(string file) :
        base(file)
    {
    }

    public override string Format => "rst";
}