namespace Pandoc;

/// <summary>
/// https://help.github.com/articles/github-flavored-markdown/
/// </summary>
public class GhMdLegacyIn :
    InOptions
{
    protected override string Format => "markdown_github";
}
