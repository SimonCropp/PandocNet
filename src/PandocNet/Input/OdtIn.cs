namespace Pandoc;

/// <summary>
/// https://en.wikipedia.org/wiki/OpenDocument
/// </summary>
public class OdtIn :
    InOptions
{
    protected override string Format => "odt";
}