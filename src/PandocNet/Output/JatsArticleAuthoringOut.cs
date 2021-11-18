namespace PandocNet;

public class JatsArticleAuthoringOut :
    OutOptions
{
    public JatsArticleAuthoringOut(Stream stream) :
        base(stream)
    {
    }

    public JatsArticleAuthoringOut(string file) :
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