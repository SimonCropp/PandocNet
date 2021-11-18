namespace PandocNet;

public class JatsArchivingOutput :
    OutputOptions
{
    public JatsArchivingOutput(Stream stream) :
        base(stream)
    {
    }

    public JatsArchivingOutput(string file) :
        base(file)
    {
    }

    public override string Format => "jats_archiving";
    //https://pandoc.org/MANUAL.html#options-affecting-specific-writers
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