namespace Pandoc;

/// <summary>
/// https://daringfireball.net/projects/markdown/
/// </summary>
public class MdStrictOut :
    OutOptions
{
    public override string Format => "markdown_strict";

    /// <summary>
    /// Use only ASCII characters in output
    /// https://pandoc.org/MANUAL.html#option--ascii
    /// </summary>
    public bool Ascii { get; set; }
    /// <summary>
    /// Use reference-style links, rather than inline links
    /// https://pandoc.org/MANUAL.html#option--reference-links
    /// </summary>
    public bool ReferenceLinks { get; set; }
    /// <summary>
    /// Specify whether footnotes (and references, if reference-links is set) are placed at the end of the current (top-level) block, the current section, or the document.
    /// https://pandoc.org/MANUAL.html#option--reference-location
    /// </summary>
    public ReferenceLocation? ReferenceLocation { get; set; }
    /// <summary>
    /// Specify whether to use ATX-style (#-prefixed) or Setext-style (underlined) headings for level 1 and 2 headings in Markdown output
    /// https://pandoc.org/MANUAL.html#option--markdown-headings
    /// </summary>
    public MarkdownHeadings? MarkdownHeadings { get; set; }

    public override IEnumerable<string> GetArguments()
    {
        foreach (var argument in base.GetArguments())
        {
            yield return argument;
        }

        if (Ascii)
        {
            yield return "--ascii";
        }
        if (ReferenceLinks)
        {
            yield return "--reference-links";
        }
        if (ReferenceLocation != null)
        {
            yield return $"--reference-location={ReferenceLocation}";
        }
        if (MarkdownHeadings != null)
        {
            yield return $"--markdown-headings={MarkdownHeadings}";
        }
    }
}