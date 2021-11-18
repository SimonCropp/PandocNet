namespace PandocNet;

public class RoffMsOutput :
    OutputOptions
{
    public RoffMsOutput(Stream stream) :
        base(stream)
    {
    }

    public RoffMsOutput(string file) :
        base(file)
    {
    }

    public override string Format => "ms";
}