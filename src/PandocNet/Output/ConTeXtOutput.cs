namespace PandocNet;

public class ConTeXtOutput :
    OutputOptions
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