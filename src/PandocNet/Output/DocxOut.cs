namespace Pandoc;

public class DocxOut :
    OutOptions
{
    public override string Format => "docx";
    
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