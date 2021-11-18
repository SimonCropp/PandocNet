namespace PandocNet;

public class ConTeXtOutput :
    InputOptions
{
    public ConTeXtOutput(Stream stream) :
        base(stream)
    {
    }

    public ConTeXtOutput(string file) :
        base(file)
    {
    }

    public override string Format => "context";
}