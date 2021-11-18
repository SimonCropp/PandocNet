namespace PandocNet;

public class RevealJsOutput :
    OutputOptions
{
    public RevealJsOutput(Stream stream) :
        base(stream)
    {
    }

    public RevealJsOutput(string file) :
        base(file)
    {
    }

    public override string Format => "revealjs";
}