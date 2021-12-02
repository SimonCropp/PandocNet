namespace Pandoc;

/// <summary>
/// https://en.wikipedia.org/wiki/OpenDocument
/// </summary>
public class OdtOut :
    OutOptions
{
    public override string Format => "odt";

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

        if (ReferenceDoc != null)
        {
            yield return $"--reference-doc={ReferenceDoc}";
        }
    }
}