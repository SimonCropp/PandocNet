namespace Pandoc;

/// <summary>
/// https://meyerweb.com/eric/tools/s5/
/// </summary>
public class S5Out :
    OutOptions
{
    public override string Format => "s5";

    /// <summary>
    /// Produce a standalone HTML file with no external dependencies, using data: URIs to incorporate the contents of linked scripts, stylesheets, images, and videos
    /// https://pandoc.org/MANUAL.html#option--self-contained
    /// </summary>
    public bool SelfContained { get; set; }
    /// <summary>
    /// Use &lt;q&gt; tags for quotes in HTML. (This option only has an effect if the smart extension is enabled for the input format used.)
    /// https://pandoc.org/MANUAL.html#option--html-q-tags
    /// </summary>
    public bool HtmlQTags { get; set; }
    /// <summary>
    /// Use only ASCII characters in output
    /// https://pandoc.org/MANUAL.html#option--ascii
    /// </summary>
    public bool Ascii { get; set; }
    /// <summary>
    /// Specifies that headings with the specified level create slides
    /// https://pandoc.org/MANUAL.html#option--slide-level
    /// </summary>
    public int? SlideLevel { get; set; }
    /// <summary>
    /// Wrap sections in &lt;section&gt; tags (or &lt;div&gt; tags for html4), and attach identifiers to the enclosing &lt;section> (or &lt;div&gt;) rather than the heading itself
    /// https://pandoc.org/MANUAL.html#option--section-divs
    /// </summary>
    public bool SectionDivs { get; set; }
    /// <summary>
    /// Specify whether footnotes (and references, if reference-links is set) are placed at the end of the current (top-level) block, the current section, or the document.
    /// https://pandoc.org/MANUAL.html#option--reference-location
    /// </summary>
    public ReferenceLocation? ReferenceLocation { get; set; }
    /// <summary>
    /// Specify STRING as a prefix at the beginning of the title that appears in the HTML header (but not in the title as it appears at the beginning of the HTML body).
    /// https://pandoc.org/MANUAL.html#option--id-prefix
    /// </summary>
    public string? IdPrefix { get; set; }
    /// <summary>
    /// Link to a CSS style sheet. This option can be used repeatedly to include multiple files. They will be included in the order specified.
    /// https://pandoc.org/MANUAL.html#option--css
    /// </summary>
    public string? Css { get; set; }
    /// <summary>
    /// Specify STRING as a prefix at the beginning of the title that appears in the HTML header (but not in the title as it appears at the beginning of the HTML body).
    /// https://pandoc.org/MANUAL.html#option--title-prefix
    /// </summary>
    public string? TitlePrefix { get; set; }

    public override IEnumerable<string> GetArguments()
    {
        foreach (var argument in base.GetArguments())
        {
            yield return argument;
        }

        if (SelfContained)
        {
            yield return "--self-contained";
        }

        if (Ascii)
        {
            yield return "--ascii";
        }

        if (HtmlQTags)
        {
            yield return "--html-q-tags";
        }
        if (SlideLevel != null)
        {
            yield return $"--slide-level={SlideLevel}";
        }
        if (SectionDivs)
        {
            yield return "--section-divs";
        }
        if (ReferenceLocation != null)
        {
            yield return $"--reference-location={ReferenceLocation}";
        }
        if (IdPrefix != null)
        {
            yield return $"--id-prefix={IdPrefix}";
        }
        if (Css != null)
        {
            yield return $"--css={Css}";
        }
        if (TitlePrefix != null)
        {
            yield return $"--title-prefix={TitlePrefix}";
        }
    }
}