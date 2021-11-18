namespace PandocNet;

public class RtfOut :
    OutOptions
{
    public RtfOut(Stream stream) :
        base(stream)
    {
    }

    public RtfOut(string file) :
        base(file)
    {
    }

    public override string Format => "rtf";
}