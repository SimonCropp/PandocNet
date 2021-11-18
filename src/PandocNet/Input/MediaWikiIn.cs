namespace PandocNet;

public class MediaWikiIn :
    InOptions
{
    public MediaWikiIn(Stream stream) :
        base(stream)
    {
    }

    public MediaWikiIn(string file) :
        base(file)
    {
    }

    public override string Format => "mediawiki";
}