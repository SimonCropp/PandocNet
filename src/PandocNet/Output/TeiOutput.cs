namespace PandocNet;

public class TeiOutput :
    OutputOptions
{
    public TeiOutput(Stream stream) :
        base(stream)
    {
    }

    public TeiOutput(string file) :
        base(file)
    {
    }

    public override string Format => "tei";
}