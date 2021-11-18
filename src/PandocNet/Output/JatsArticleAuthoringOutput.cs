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
}