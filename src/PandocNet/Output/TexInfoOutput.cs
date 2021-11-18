namespace PandocNet;

public class TexInfoOutput :
    OutputOptions
{
    public TexInfoOutput(Stream stream) :
        base(stream)
    {
    }

    public TexInfoOutput(string file) :
        base(file)
    {
    }

    public override string Format => "texinfo";
}