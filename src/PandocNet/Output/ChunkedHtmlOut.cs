namespace Pandoc;

/// <summary>
/// https://pandoc.org/chunkedhtml-demo/demo.html
/// </summary>
public class ChunkedHtmlOut :
    OutOptions
{
    public override string Format => "chunkedhtml";
}
