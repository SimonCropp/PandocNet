namespace Pandoc;

/// <summary>
/// https://zim-wiki.org/manual/Help/Wiki_Syntax.html
/// </summary>
public class ZimWikiOut :
    OutOptions
{
    public override string Format => "zimwiki";
}