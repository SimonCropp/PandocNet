namespace PandocNet;

public class MediaWikiInput :
    InputOptions
{
    public MediaWikiInput(Stream stream) :
        base(stream)
    {
    }

    public MediaWikiInput(string file) :
        base(file)
    {
    }

    public override string Format => "mediawiki";
}