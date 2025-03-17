namespace Pandoc;

/// <summary>
/// https://en.wikipedia.org/wiki/Office_Open_XML
/// </summary>
public class DocxIn :
    InOptions
{
    protected override string Format => "docx";

    /// <summary>
    /// Specifies what to do with insertions, deletions, and comments produced
    /// https://pandoc.org/MANUAL.html#option--track-changes
    /// </summary>
    public TrackChanges? TrackChanges { get; set; }

    public override IEnumerable<string> GetArguments()
    {
        foreach (var argument in base.GetArguments())
        {
            yield return argument;
        }

        if (TrackChanges != null)
        {
            yield return $"--track-changes={TrackChanges.Value.ToString().ToLower()}";
        }
    }
}