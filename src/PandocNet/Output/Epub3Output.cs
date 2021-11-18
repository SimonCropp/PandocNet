namespace PandocNet;

public class Epub3Output :
    OutputOptions
{
    public Epub3Output(Stream stream) :
        base(stream)
    {
    }

    public Epub3Output(string file) :
        base(file)
    {
    }

    public override string Format => "epub3";

    //https://pandoc.org/MANUAL.html#options-affecting-specific-writers
    public ReferenceLocation? ReferenceLocation { get; set; }
    public bool NumberSections { get; set; }
    public string? Css { get; set; }
    public string? CoverImage { get; set; }
    public string? Metadata { get; set; }
    public string? SubDirectory { get; set; }
    public string? EmbedFont { get; set; }
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