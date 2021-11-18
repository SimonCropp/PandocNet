namespace PandocNet;

public class PptxOutput :
    OutputOptions
{
    public PptxOutput(Stream stream) :
        base(stream)
    {
    }

    public PptxOutput(string file) :
        base(file)
    {
    }

    public override string Format => "pptx";
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