namespace Pandoc;

/// <summary>
/// https://pandoc.org/MANUAL.html
/// </summary>
public class Epub3Out :
    OutOptions
{
    public override string Format => "epub3";

    /// <summary>
    /// Specify whether footnotes (and references, if reference-links is set) are placed at the end of the current (top-level) block, the current section, or the document.
    /// https://pandoc.org/MANUAL.html#option--reference-location
    /// </summary>
    public ReferenceLocation? ReferenceLocation { get; set; }

    /// <summary>
    /// Number section headings
    /// https://pandoc.org/MANUAL.html#option--number-sections
    /// </summary>
    public bool NumberSections { get; set; }

    /// <summary>
    /// Link to a CSS style sheet. This option can be used repeatedly to include multiple files. They will be included in the order specified.
    /// https://pandoc.org/MANUAL.html#option--css
    /// </summary>
    public string? Css { get; set; }

    /// <summary>
    /// Use the specified image as the EPUB cover
    /// https://pandoc.org/MANUAL.html#option--epub-cover-image
    /// </summary>
    public string? CoverImage { get; set; }

    /// <summary>
    /// Look in the specified XML file for metadata for the EPUB.
    /// https://pandoc.org/MANUAL.html#option--epub-metadata
    /// </summary>
    public string? Metadata { get; set; }

    /// <summary>
    /// Specify the subdirectory in the OCF container that is to hold the EPUB-specific contents
    /// https://pandoc.org/MANUAL.html#option--epub-subdirectory
    /// </summary>
    public string? SubDirectory { get; set; }

    /// <summary>
    /// Embed the specified font in the EPUB. This option can be repeated to embed multiple fonts
    /// https://pandoc.org/MANUAL.html#option--epub-embed-font
    /// </summary>
    public string? EmbedFont { get; set; }

    /// <summary>
    /// Specify the heading level at which to split the EPUB into separate “chapter” files
    /// https://pandoc.org/MANUAL.html#option--epub-chapter-level
    /// </summary>
    public int? ChapterLevel { get; set; }

    public override IEnumerable<string> GetArguments()
    {
        foreach (var argument in base.GetArguments())
        {
            yield return argument;
        }

        if (ReferenceLocation != null)
        {
            yield return $"--reference-location={ReferenceLocation}";
        }

        if (NumberSections)
        {
            yield return "--number-sections";
        }

        if (Css != null)
        {
            yield return $"--css={Css}";
        }

        if (CoverImage != null)
        {
            yield return $"--epub-cover-image={CoverImage}";
        }

        if (Metadata != null)
        {
            yield return $"--epub-metadata={Metadata}";
        }

        if (EmbedFont != null)
        {
            yield return $"--epub-embed-font={EmbedFont}";
        }

        if (ChapterLevel != null)
        {
            yield return $"--epub-chapter-level={ChapterLevel}";
        }

        if (SubDirectory != null)
        {
            yield return $"--epub-subdirectory={SubDirectory}";
        }
    }
}