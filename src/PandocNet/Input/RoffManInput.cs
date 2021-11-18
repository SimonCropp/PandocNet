namespace PandocNet;

public class RoffManInput :
    InputOptions
{
    public RoffManInput(Stream stream) :
        base(stream)
    {
    }

    public RoffManInput(string file) :
        base(file)
    {
    }

    public override string Format => "man";
}