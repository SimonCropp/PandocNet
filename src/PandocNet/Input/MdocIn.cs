namespace Pandoc;

/// <summary>
/// https://man.openbsd.org/mdoc.7
/// </summary>
public class MdocIn :
    InOptions
{
    protected override string Format => "mdoc";
}
