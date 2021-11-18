namespace PandocNet;

public abstract class InOptions :
    IDisposable
{
    bool isOwned;
    public Stream Stream { get; }

    //https://pandoc.org/MANUAL.html#reader-options
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

        if (TrackChanges == PandocNet.TrackChanges.Accept)
        {
            yield return "--track-changes=accept";
        }

        if (TrackChanges == PandocNet.TrackChanges.All)
        {
            yield return "--track-changes=all";
        }

        if (TrackChanges == PandocNet.TrackChanges.Reject)
        {
            yield return "--track-changes=reject";
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

    public InOptions(Stream stream)
    {
        Stream = stream;
    }

    public InOptions(string file)
    {
        Stream = File.OpenRead(file);
        isOwned = true;
    }

    public void Dispose()
    {
        if (isOwned)
        {
            Stream.Dispose();
        }
    }
}

public enum TrackChanges
{
    Accept,
    Reject,
    All
}