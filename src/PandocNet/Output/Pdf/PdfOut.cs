namespace PandocNet;

public class PdfOut :
    OutOptions
{
    public override string Format => "pdf";
    //https://pandoc.org/MANUAL.html#options-affecting-specific-writers
    public PdfEngine? Engine { get; set; }

    public override IEnumerable<string> GetArguments()
    {
        foreach (var argument in base.GetArguments())
        {
            yield return argument;
        }

        if (Engine != null)
        {
            yield return $"---engine={Engine.Value.ToString().ToLower()}";
        }
    }
}