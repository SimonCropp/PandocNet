namespace Pandoc;

/// <summary>
/// https://en.wikipedia.org/wiki/RIS_(file_format)
/// </summary>
public class RisIn :
    InOptions
{
    protected override string Format => "ris";
}
