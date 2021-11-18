namespace PandocNet;

public class RtfInput :
    InputOptions
{
    public RtfInput(Stream stream) :
        base(stream)
    {
    }

    public RtfInput(string file) :
        base(file)
    {
    }

    public override string Format => "rtf";
}