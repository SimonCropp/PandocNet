namespace Pandoc;

/// <summary>
/// https://ctan.org/pkg/bibtex
/// </summary>
public class BibTeXOut :
    OutOptions
{
    public override string Format => "bibtex";
}