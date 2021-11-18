namespace PandocNet;

public class BeamerOutput :
    InputOptions
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