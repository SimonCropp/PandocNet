namespace Pandoc;

/// <summary>
/// https://www.adobe.com/acrobat/about-adobe-pdf.html
/// </summary>
public class PdfOut :
    OutOptions
{
    public override string Format => "pdf";

    public PdfEngine? Engine { get; set; }

    public override IEnumerable<string> GetArguments()
    {
        foreach (var argument in base.GetArguments())
        {
            yield return argument;
        }

        if (Engine != null)
        {
            yield return $"---engine={Engine.Value.ToString().ToLower()}";
        }
    }
}