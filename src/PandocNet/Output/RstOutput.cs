namespace PandocNet;

public class RstOutput :
    OutputOptions
{
    public RstOutput(Stream stream) :
        base(stream)
    {
    }

    public RstOutput(string file) :
        base(file)
    {
    }

    public override string Format => "rst";
}