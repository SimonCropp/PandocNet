namespace Pandoc;

public class JatsArchivingOut :
    OutOptions
{
    public override string Format => "jats_archiving";
    
    public bool Ascii { get; set; }

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
    }
}