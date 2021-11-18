namespace Pandoc;

public class RoffMsOut :
    OutOptions
{
    public override string Format => "ms";
    
    public bool Ascii { get; set; }
    public bool NumberSections { get; set; }

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

        if (NumberSections)
        {
            yield return "--number-sections";
        }
    }
}