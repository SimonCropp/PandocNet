namespace PandocNet;

public class OpmlOutput :
    OutputOptions
{
    public OpmlOutput(Stream stream) :
        base(stream)
    {
    }

    public OpmlOutput(string file) :
        base(file)
    {
    }

    public override string Format => "opml";
}