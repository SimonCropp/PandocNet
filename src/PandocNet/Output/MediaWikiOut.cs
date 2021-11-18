namespace PandocNet;

public class MediaWikiOut :
    OutOptions
{
    public MediaWikiOut(Stream stream) :
        base(stream)
    {
    }

    public MediaWikiOut(string file) :
        base(file)
    {
    }

    public override string Format => "mediawiki";
}