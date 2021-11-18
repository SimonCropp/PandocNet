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
}