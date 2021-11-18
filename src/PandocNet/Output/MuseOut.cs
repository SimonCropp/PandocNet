namespace PandocNet;

public class MuseOut :
    OutOptions
{
    public override string Format => "muse";  
    //https://pandoc.org/MANUAL.html#options-affecting-specific-writers
    public ReferenceLocation? ReferenceLocation { get; set; }

    public override IEnumerable<string> GetArguments()
    {
        foreach (var argument in base.GetArguments())
        {
            yield return argument;
        }
        
        if (ReferenceLocation != null)
        {
            yield return $"--reference-location={ReferenceLocation}";
        }
    }
}