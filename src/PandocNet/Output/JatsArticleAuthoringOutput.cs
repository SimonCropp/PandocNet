namespace PandocNet;

public class JatsArticleAuthoringOutput :
    OutputOptions
{
    public JatsArticleAuthoringOutput(Stream stream) :
        base(stream)
    {
    }

    public JatsArticleAuthoringOutput(string file) :
        base(file)
    {
    }

    public override string Format => "jats_articleauthoring";
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