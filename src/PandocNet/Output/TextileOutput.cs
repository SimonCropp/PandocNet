namespace PandocNet;

public class TextileOutput :
    OutputOptions
{
    public TextileOutput(Stream stream) :
        base(stream)
    {
    }

    public TextileOutput(string file) :
        base(file)
    {
    }

    public override string Format => "textile";
}