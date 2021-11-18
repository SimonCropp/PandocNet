namespace PandocNet;

public class GhMdOutput :
    OutputOptions
{
    public GhMdOutput(Stream stream) :
        base(stream)
    {
    }

    public GhMdOutput(string file) :
        base(file)
    {
    }

    public override string Format => "gfm";

    //https://pandoc.org/MANUAL.html#options-affecting-specific-writers
    public bool Ascii { get; set; }
    public bool ReferenceLinks { get; set; }
    public ReferenceLocation? ReferenceLocation { get; set; }
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