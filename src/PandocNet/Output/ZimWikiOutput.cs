namespace PandocNet;

public class ZimWikiOutput :
    OutputOptions
{
    public ZimWikiOutput(Stream stream) :
        base(stream)
    {
    }

    public ZimWikiOutput(string file) :
        base(file)
    {
    }

    public override string Format => "zimwiki";
}