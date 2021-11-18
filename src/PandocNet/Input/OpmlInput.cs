namespace PandocNet;

public class OpmlInput :
    InputOptions
{
    public OpmlInput(Stream stream) :
        base(stream)
    {
    }

    public OpmlInput(string file) :
        base(file)
    {
    }

    public override string Format => "opml";
}