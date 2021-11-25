namespace Pandoc;

/// <summary>
/// https://en.wikipedia.org/wiki/Office_Open_XML
/// </summary>
public class DocxOut :
    OutOptions
{
    public override string Format => "docx";

    /// <summary>
    /// Number section headings
    /// https://pandoc.org/MANUAL.html#option--number-sections
    /// </summary>
    public bool NumberSections { get; set; }
    /// <summary>
    /// Use the specified file as a style reference in producing
    /// https://pandoc.org/MANUAL.html#option--reference-doc
    /// </summary>
    public string? ReferenceDoc { get; set; }

    public override IEnumerable<string> GetArguments()
    {
        foreach (var argument in base.GetArguments())
        {
            yield return argument;
        }

        if (NumberSections)
        {
            yield return "--number-sections";
        }
        if (ReferenceDoc!= null)
        {
            yield return $"--reference-doc={ReferenceDoc}";
        }
    }
}