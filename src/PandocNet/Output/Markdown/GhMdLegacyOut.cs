namespace Pandoc;

/// <summary>
/// https://github.github.com/gfm/
/// </summary>
public class GhMdLegacyOut :
    OutOptions
{
    public override string Format => "markdown_github";
}
