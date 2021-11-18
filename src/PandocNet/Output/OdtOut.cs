namespace PandocNet;

public class OdtOut :
    OutOptions
{
    public OdtOut(Stream stream) :
        base(stream)
    {
    }

    public OdtOut(string file) :
        base(file)
    {
    }

    public override string Format => "odt"; 
    //https://pandoc.org/MANUAL.html#options-affecting-specific-writers
    public string? ReferenceDoc { get; set; }

    public override IEnumerable<string> GetArguments()
    {
        foreach (var argument in base.GetArguments())
        {
            yield return argument;
        }

        if (ReferenceDoc != null)
        {
            yield return $"--reference-doc={ReferenceDoc}";
        }
    }
}