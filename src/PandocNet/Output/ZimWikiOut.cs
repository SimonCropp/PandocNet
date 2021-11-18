namespace PandocNet;

public class ZimWikiOut :
    OutOptions
{
    public ZimWikiOut(Stream stream) :
        base(stream)
    {
    }

    public ZimWikiOut(string file) :
        base(file)
    {
    }

    public override string Format => "zimwiki";
}