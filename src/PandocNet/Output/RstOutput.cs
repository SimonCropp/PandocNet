namespace PandocNet;

public class RstOutput :
    OutputOptions
{
    public RstOutput(Stream stream) :
        base(stream)
    {
    }

    public RstOutput(string file) :
        base(file)
    {
    }

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