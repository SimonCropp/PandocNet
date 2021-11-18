namespace PandocNet;

public class LaTeXOut :
    OutOptions
{
    public LaTeXOut(Stream stream) :
        base(stream)
    {
    }

    public LaTeXOut(string file) :
        base(file)
    {
    }

    public override string Format => "latex";
    //https://pandoc.org/MANUAL.html#options-affecting-specific-writers
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