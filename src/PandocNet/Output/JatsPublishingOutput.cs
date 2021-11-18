namespace PandocNet;

public class JatsPublishingOutput :
    OutputOptions
{
    public JatsPublishingOutput(Stream stream) :
        base(stream)
    {
    }

    public JatsPublishingOutput(string file) :
        base(file)
    {
    }

    public override string Format => "jats_publishing";
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