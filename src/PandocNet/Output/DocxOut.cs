namespace PandocNet;

public class DocxOut :
    OutOptions
{
    public DocxOut(Stream stream) :
        base(stream)
    {
    }

    public DocxOut(string file) :
        base(file)
    {
    }

    public override string Format => "docx";
    //https://pandoc.org/MANUAL.html#options-affecting-specific-writers
    public bool NumberSections { get; set; }
    public string? ReferenceDoc { get; set; }

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
        if (ReferenceDoc!= null)
        {
            yield return $"--reference-doc={ReferenceDoc}";
        }
    }
}