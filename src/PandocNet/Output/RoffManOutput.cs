namespace PandocNet;

public class RoffManOutput :
    OutputOptions
{
    public RoffManOutput(Stream stream) :
        base(stream)
    {
    }

    public RoffManOutput(string file) :
        base(file)
    {
    }

    public override string Format => "man";
}