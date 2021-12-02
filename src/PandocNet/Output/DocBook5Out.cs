namespace Pandoc;

/// <summary>
/// https://docbook.org/
/// </summary>
public class DocBook5Out :
    OutOptions
{
    public override string Format => "docbook5";

    /// <summary>
    /// Treat top-level headings as the given division output.The hierarchy order is part, chapter, then section; all headings are shifted such that the top-level heading becomes the specified type
    /// https://pandoc.org/MANUAL.html#option--top-level-division
    /// </summary>
    public TopLevelDivision? TopLevelDivision { get; set; }
    /// <summary>
    /// Specify STRING as a prefix at the beginning of the title that appears in the HTML header (but not in the title as it appears at the beginning of the HTML body).
    /// https://pandoc.org/MANUAL.html#option--id-prefix
    /// </summary>
    public string? IdPrefix { get; set; }

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
        if (IdPrefix != null)
        {
            yield return $"--id-prefix={IdPrefix}";
        }
    }
}