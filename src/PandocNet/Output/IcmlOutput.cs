namespace PandocNet;

public class IcmlOutput :
    OutputOptions
{
    public IcmlOutput(Stream stream) :
        base(stream)
    {
    }

    public IcmlOutput(string file) :
        base(file)
    {
    }

    public override string Format => "icml";
}