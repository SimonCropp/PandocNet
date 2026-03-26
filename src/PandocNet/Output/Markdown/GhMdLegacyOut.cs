namespace Pandoc;

/// <summary>
/// https://help.github.com/articles/github-flavored-markdown/
/// </summary>
public class GhMdLegacyOut :
    OutOptions
{
    public override string Format => "markdown_github";
}
