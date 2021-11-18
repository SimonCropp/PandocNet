namespace PandocNet;

public class ConTeXtOutput :
    OutputOptions
{
    public ConTeXtOutput(Stream stream) :
        base(stream)
    {
    }

    public ConTeXtOutput(string file) :
        base(file)
    {
    }

    public override string Format => "context"; 
    //https://pandoc.org/MANUAL.html#options-affecting-specific-writers
    public TopLevelDivision? TopLevelDivision { get; set; }
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