namespace PandocNet;

public class RoffManIn :
    InOptions
{
    public RoffManIn(Stream stream) :
        base(stream)
    {
    }

    public RoffManIn(string file) :
        base(file)
    {
    }

    public override string Format => "man";
}