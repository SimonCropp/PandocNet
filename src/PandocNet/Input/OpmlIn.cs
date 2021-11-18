namespace PandocNet;

public class OpmlIn :
    InOptions
{
    public OpmlIn(Stream stream) :
        base(stream)
    {
    }

    public OpmlIn(string file) :
        base(file)
    {
    }

    public override string Format => "opml";
}