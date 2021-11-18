namespace PandocNet;

public class OpmlOut :
    OutOptions
{
    public OpmlOut(Stream stream) :
        base(stream)
    {
    }

    public OpmlOut(string file) :
        base(file)
    {
    }

    public override string Format => "opml";
}