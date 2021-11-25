namespace Pandoc;

/// <summary>
/// http://idpf.org/epub
/// </summary>
public class EpubIn :
    InOptions
{
    protected override string Format => "epub";
}