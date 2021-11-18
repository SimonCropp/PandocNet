namespace PandocNet;

public class GhMdIn :
    InOptions
{
    public GhMdIn(Stream stream) :
        base(stream)
    {
    }

    public GhMdIn(string file) :
        base(file)
    {
    }

    public override string Format => "gfm";
}

