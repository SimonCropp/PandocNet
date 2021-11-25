namespace Pandoc;

/// <summary>
/// https://help.github.com/articles/github-flavored-markdown/
/// </summary>
public class GhMdIn :
    InOptions
{
    protected override string Format => "gfm";
}

