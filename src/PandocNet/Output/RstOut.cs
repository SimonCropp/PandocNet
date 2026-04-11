namespace Pandoc;

/// <summary>
/// https://docutils.sourceforge.io/docs/ref/rst/introduction.html
/// </summary>
public class RstOut :
    OutOptions
{
    public override string Format => "rst";
    /// <summary>
    /// Use reference-style links, rather than inline links
    /// https://pandoc.org/MANUAL.html#option--reference-links%5B
    /// </summary>
    public bool ReferenceLinks { get; set; }

    /// <summary>
    /// Render tables as RST list tables.
    /// https://pandoc.org/MANUAL.html#option--list-tables
    /// </summary>
    public bool ListTables { get; set; }

    public override IEnumerable<string> GetArguments()
    {
        foreach (var argument in base.GetArguments())
        {
            yield return argument;
        }

        if (ReferenceLinks)
        {
            yield return "--reference-links";
        }

        if (ListTables)
        {
            yield return "--list-tables";
        }
    }
}