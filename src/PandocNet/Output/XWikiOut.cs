namespace Pandoc;

/// <summary>
/// https://www.xwiki.org/xwiki/bin/view/Documentation/UserGuide/Features/XWikiSyntax/
/// </summary>
public class XWikiOut :
    OutOptions
{
    public override string Format => "xwiki";
}