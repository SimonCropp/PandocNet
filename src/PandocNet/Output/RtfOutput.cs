namespace PandocNet;

public class RtfOutput :
    OutputOptions
{
    public RtfOutput(Stream stream) :
        base(stream)
    {
    }

    public RtfOutput(string file) :
        base(file)
    {
    }

    public override string Format => "rtf";
}