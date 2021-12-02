namespace Pandoc;

/// <summary>
/// https://github.com/TEIC/TEI-Simple
/// </summary>
public class TeiOut :
    OutOptions
{
    public override string Format => "tei";

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

    public override IEnumerable<string> GetArguments()
    {
        foreach (var argument in base.GetArguments())
        {
            yield return argument;
        }

        if (TopLevelDivision != null)
        {
            yield return $"--top-level-division={TopLevelDivision}";
        }
        if (NumberSections)
        {
            yield return "--number-sections";
        }
    }
}