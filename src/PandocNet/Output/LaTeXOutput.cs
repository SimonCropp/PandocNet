namespace PandocNet;

public class LaTeXOutput :
    OutputOptions
{
    public LaTeXOutput(Stream stream) :
        base(stream)
    {
    }

    public LaTeXOutput(string file) :
        base(file)
    {
    }

    public override string Format => "latex";
}