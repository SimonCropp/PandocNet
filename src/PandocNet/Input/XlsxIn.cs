namespace Pandoc;

/// <summary>
/// https://en.wikipedia.org/wiki/Office_Open_XML
/// </summary>
public class XlsxIn :
    InOptions
{
    protected override string Format => "xlsx";
}
