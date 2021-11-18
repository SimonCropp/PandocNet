namespace PandocNet;

public class RstOut :
    OutOptions
{
    public override string Format => "rst";   //https://pandoc.org/MANUAL.html#options-affecting-specific-writers
    public bool ReferenceLinks { get; set; }

    public override IEnumerable<string> GetArguments()
    {
        foreach (var argument in base.GetArguments())
        {
            yield return argument;
        }
        
        if (ReferenceLinks)
        {
            yield return "--reference-links";
        }
    }
}