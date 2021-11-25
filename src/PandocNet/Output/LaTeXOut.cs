namespace Pandoc;

/// <summary>
/// https://pandoc.org/MANUAL.html
/// </summary>
public class LaTeXOut :
    OutOptions
{
    public override string Format => "latex";

    /// <summary>
    /// Use only ASCII characters in output
    /// https://pandoc.org/MANUAL.html#option--ascii
    /// </summary>
    public bool Ascii { get; set; }
    /// <summary>
    /// Treat top-level headings as the given division output.The hierarchy order is part, chapter, then section; all headings are shifted such that the top-level heading becomes the specified type
    /// https://pandoc.org/MANUAL.html#option--top-level-division
    /// </summary>
    public TopLevelDivision? TopLevelDivision { get; set; }
    /// <summary>
    /// Number section headings
    /// https://pandoc.org/MANUAL.html#option--number-sections
    /// </summary>
    public bool NumberSections { get; set; }
    /// <summary>
    /// Number section headings
    /// https://pandoc.org/MANUAL.html#option--number-sections
    /// </summary>
    public bool Listings { get; set; }
    
    public override IEnumerable<string> GetArguments()
    {
        foreach (var argument in base.GetArguments())
        {
            yield return argument;
        }

        if (Ascii)
        {
            yield return "--ascii";
        }

        if (TopLevelDivision!= null)
        {
            yield return $"--top-level-division={TopLevelDivision}";
        }
        if (NumberSections)
        {
            yield return "--number-sections";
        }
        if (Listings)
        {
            yield return "--listings";
        }
    }
}