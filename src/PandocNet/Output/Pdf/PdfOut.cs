namespace Pandoc;

/// <summary>
/// https://www.adobe.com/acrobat/about-adobe-pdf.html
/// </summary>
public class PdfOut :
    OutOptions
{
    public override string Format => "pdf";

    /// <summary>
    /// Specify the name of the engine to look for on the path.
    /// </summary>
    /// <remarks>
    /// 'EnginePath' takes precedence over this property.
    /// </remarks>
    public PdfEngine? Engine { get; set; }
    
    /// <summary>
    /// Specify the location of the engine.
    /// </summary>
    /// <remarks>
    /// This takes precedence over the 'Engine' property.
    /// </remarks>
    public string? EnginePath { get; set; }
    
    public override IEnumerable<string> GetArguments()
    {
        foreach (var argument in base.GetArguments())
        {
            yield return argument;
        }

        if (!string.IsNullOrEmpty(EnginePath))
        {
            yield return $"--pdf-engine={EnginePath}";
        }
        else if (Engine != null)
        {
            yield return $"--pdf-engine={Engine.Value.ToString().ToLower()}";
        }
    }
}