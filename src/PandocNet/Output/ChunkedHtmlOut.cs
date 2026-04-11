namespace Pandoc;

/// <summary>
/// https://pandoc.org/MANUAL.html#option--to
/// </summary>
public class ChunkedHtmlOut :
    OutOptions
{
    public override string Format => "chunkedhtml";

    /// <summary>
    /// Specify the heading level at which to split into separate chunk files.
    /// https://pandoc.org/MANUAL.html#option--split-level
    /// </summary>
    public int? SplitLevel { get; set; }

    /// <summary>
    /// Specify a template for the filenames in chunked HTML output.
    /// https://pandoc.org/MANUAL.html#option--chunk-template
    /// </summary>
    public string? ChunkTemplate { get; set; }

    public override IEnumerable<string> GetArguments()
    {
        foreach (var argument in base.GetArguments())
        {
            yield return argument;
        }

        if (SplitLevel != null)
        {
            yield return $"--split-level={SplitLevel}";
        }

        if (ChunkTemplate != null)
        {
            yield return $"--chunk-template={ChunkTemplate}";
        }
    }
}
