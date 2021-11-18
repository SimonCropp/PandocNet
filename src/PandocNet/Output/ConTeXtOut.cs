namespace Pandoc;

public class ConTeXtOut :
    OutOptions
{
    public override string Format => "context";

    public bool NumberSections { get; set; }
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