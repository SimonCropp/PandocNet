namespace Pandoc;

/// <summary>
/// https://pandoc.org/MANUAL.html#option--to
/// </summary>
public class ChunkedHtmlOut :
    OutOptions
{
    public override string Format => "chunkedhtml";
}
