namespace Pandoc;

public class LaTeXOut :
    OutOptions
{
    public override string Format => "latex";
    
    public bool Ascii { get; set; }
    public TopLevelDivision? TopLevelDivision { get; set; }
    public bool NumberSections { get; set; }
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