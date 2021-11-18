namespace PandocNet;

public class LatexInput :
    InputOptions
{
    public LatexInput(Stream stream) :
        base(stream)
    {
    }

    public LatexInput(string file) :
        base(file)
    {
    }

    public override string Format => "latex";
}