namespace PandocNet;

public class IcmlOut :
    OutOptions
{
    public IcmlOut(Stream stream) :
        base(stream)
    {
    }

    public IcmlOut(string file) :
        base(file)
    {
    }

    public override string Format => "icml";
}