namespace Pandoc;

/// <summary>
/// Treat top-level headings as the given division type in LaTeX, ConTeXt, DocBook, and TEI output
/// https://pandoc.org/MANUAL.html#option--top-level-division
/// </summary>
public enum TopLevelDivision
{
    Default,
    Section,
    Chapter,
    Part
}