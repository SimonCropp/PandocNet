namespace Pandoc;

public class RstOut :
    OutOptions
{
    public override string Format => "rst";   
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