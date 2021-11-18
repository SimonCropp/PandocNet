namespace PandocNet;

public class MediaWikiOutput :
    OutputOptions
{
    public MediaWikiOutput(Stream stream) :
        base(stream)
    {
    }

    public MediaWikiOutput(string file) :
        base(file)
    {
    }

    public override string Format => "mediawiki";
}