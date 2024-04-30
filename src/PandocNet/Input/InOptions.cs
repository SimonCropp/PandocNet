namespace Pandoc;

public abstract class InOptions
{
    /// <summary>
    /// Shift heading levels by a positive or negative integer
    /// https://pandoc.org/MANUAL.html#option--shift-heading-level-by
    /// </summary>
    public int ShiftHeadingLevelBy { get; set; }
    /// <summary>
    /// Specify the number of spaces per tab (default is 4).
    /// https://pandoc.org/MANUAL.html#option--tab-stop
    /// </summary>
    public int? TabStop { get; set; }
    /// <summary>
    /// Specify classes to use for indented code blocks
    /// https://pandoc.org/MANUAL.html#option--indented-code-classes
    /// </summary>
    public IList<string>? IndentedCodeClasses { get; set; }
    /// <summary>
    /// Parse each file individually before combining for multifile documents
    /// https://pandoc.org/MANUAL.html#option--file-scope
    /// </summary>
    public bool FileScope { get; set; }
    /// <summary>
    /// Preserve tabs instead of converting them to spaces. (By default, pandoc converts tabs to spaces before parsing its input.)
    /// https://pandoc.org/MANUAL.html#option--preserve-tabs
    /// </summary>
    public bool PreserveTabs { get; set; }
    /// <summary>
    /// Specify an executable to be used as a filter transforming the pandoc AST after the input is parsed and before the output is written. The executable should read JSON from stdin and write JSON to stdout
    /// https://pandoc.org/MANUAL.html#option--filter
    /// </summary>
    public string? Filter { get; set; }
    /// <summary>
    /// Transform the document in a similar fashion as JSON filters (see --filter), but use pandoc’s built-in Lua filtering system.
    /// https://pandoc.org/MANUAL.html#option--lua-filter
    /// </summary>
    public string? LuaFilter { get; set; }
    //TODO:--metadata
    /// <summary>
    /// Set the metadata field KEY to the value VAL. A value specified on the command line overrides a value specified in the document using YAML metadata blocks. Values will be parsed as YAML boolean or string values. If no value is specified, the value will be treated as Boolean true.
    /// https://pandoc.org/MANUAL.html#option--metadata
    /// </summary>
    public string? Metadata { get; set; }
    /// <summary>
    /// Extract images and other media contained in or linked from the source document to the path DIR, creating it if necessary, and adjust the images references in the document so they point to the extracted files.
    /// https://pandoc.org/MANUAL.html#option--extract-media
    /// </summary>
    public string? ExtractMedia{ get; set; }
    /// <summary>
    /// Specifies a custom abbreviations file, with abbreviations one to a line.
    /// https://pandoc.org/MANUAL.html#option--abbreviations
    /// </summary>
    public string? Abbreviations{ get; set; }

    protected abstract string Format { get; }

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
            yield return $"--preserve-tabs";
        }

        if (TabStop != null)
        {
            yield return $"--tab-stop={TabStop}";
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