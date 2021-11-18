namespace PandocNet;

public abstract class InOptions
{
    public int ShiftHeadingLevelBy { get; set; }
    public int? TabStop { get; set; }
    public IList<string>? IndentedCodeClasses { get; set; }
    public bool FileScope { get; set; }
    public bool PreserveTabs { get; set; }
    public string? Filter { get; set; }
    public string? LuaFilter { get; set; }
    //TODO:--metadata
    public string? Metadata { get; set; }
    public string? ExtractMedia{ get; set; }
    public string? Abbreviations{ get; set; }
    public TrackChanges? TrackChanges { get; set; }
    public abstract string Format { get; }

    public virtual IEnumerable<string> GetArguments()
    {
        yield return $"--from={Format}";

        if (ShiftHeadingLevelBy != 0)
        {
            yield return $"--shift-heading-level-by={ShiftHeadingLevelBy}";
        }

        if (IndentedCodeClasses != null)
        {
            yield return $"--indented-code-classes={string.Join(",", IndentedCodeClasses)}";
        }

        if (FileScope)
        {
            yield return "file-scope";
        }

        if (Filter != null)
        {
            yield return $"--filter={Filter}";
        }

        if (LuaFilter != null)
        {
            yield return $"--lua-filter={LuaFilter}";
        }

        if (Metadata != null)
        {
            yield return $"--metadata-file={Metadata}";
        }

        if (PreserveTabs)
        {
            yield return $"--preserve-tabs={PreserveTabs}";
        }

        if (TabStop != null)
        {
            yield return $"--tab-stop={TabStop}";
        }

        if (TrackChanges != null)
        {
            yield return $"--track-changes=accept{TrackChanges.Value.ToString().ToLower()}";
        }

        if (ExtractMedia != null)
        {
            yield return $"--extract-media={ExtractMedia}";
        }

        if (Abbreviations != null)
        {
            yield return $"--abbreviations={Abbreviations}";
        }
    }
}