namespace Pandoc;

/// <summary>
/// https://www.mediawiki.org/wiki/Help:Formatting
/// </summary>
public class MediaWikiOut :
    OutOptions
{
    public override string Format => "mediawiki";
}