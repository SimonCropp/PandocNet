namespace PandocNet;

public class XWikiOutput :
    OutputOptions
{
    public XWikiOutput(Stream stream) :
        base(stream)
    {
    }

    public XWikiOutput(string file) :
        base(file)
    {
    }

    public override string Format => "xwiki";
}