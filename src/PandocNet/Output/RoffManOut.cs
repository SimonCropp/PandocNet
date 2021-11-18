namespace PandocNet;

public class RoffManOut :
    OutOptions
{
    public RoffManOut(Stream stream) :
        base(stream)
    {
    }

    public RoffManOut(string file) :
        base(file)
    {
    }

    public override string Format => "man";
}