namespace Pandoc;

/// <summary>
/// https://www.contextgarden.net/
/// </summary>
public class ConTeXtOut :
    OutOptions
{
    public override string Format => "context";

    /// <summary>
    /// Number section headings
    /// https://pandoc.org/MANUAL.html#option--number-sections
    /// </summary>
    public bool NumberSections { get; set; }
    /// <summary>
    /// Treat top-level headings as the given division output.The hierarchy order is part, chapter, then section; all headings are shifted such that the top-level heading becomes the specified type
    /// https://pandoc.org/MANUAL.html#option--top-level-division
    /// </summary>
    public TopLevelDivision? TopLevelDivision { get; set; }

    public override IEnumerable<string> GetArguments()
    {
        foreach (var argument in base.GetArguments())
        {
            yield return argument;
        }

        if (NumberSections)
        {
            yield return "--number-sections";
        }

        if (TopLevelDivision != null)
        {
            yield return $"--top-level-division={TopLevelDivision}";
        }
    }
}