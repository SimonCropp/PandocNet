namespace Pandoc;

/// <summary>
/// https://ctan.org/pkg/bibtex
/// </summary>
public class BibTexIn :
    InOptions
{
    protected override string Format => "bibtex";
}