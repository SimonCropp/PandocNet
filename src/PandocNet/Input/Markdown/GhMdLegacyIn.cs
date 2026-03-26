namespace Pandoc;

/// <summary>
/// https://github.github.com/gfm/
/// </summary>
public class GhMdLegacyIn :
    InOptions
{
    protected override string Format => "markdown_github";
}
