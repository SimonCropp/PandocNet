namespace PandocNet;

public class BeamerOutput :
    OutputOptions
{
    public BeamerOutput(Stream stream) :
        base(stream)
    {
    }

    public BeamerOutput(string file) :
        base(file)
    {
    }

    public override string Format => "beamer";
}