namespace Pandoc;

/// <summary>
/// https://en.wikipedia.org/wiki/EPUB
/// </summary>
public class EpubIn :
    InOptions
{
    protected override string Format => "epub";
}