namespace PandocNet;

public class RtfIn :
    InOptions
{
    public RtfIn(Stream stream) :
        base(stream)
    {
    }

    public RtfIn(string file) :
        base(file)
    {
    }

    public override string Format => "rtf";
}