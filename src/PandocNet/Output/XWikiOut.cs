namespace PandocNet;

public class XWikiOut :
    OutOptions
{
    public XWikiOut(Stream stream) :
        base(stream)
    {
    }

    public XWikiOut(string file) :
        base(file)
    {
    }

    public override string Format => "xwiki";
}