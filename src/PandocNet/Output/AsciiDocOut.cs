namespace PandocNet;

public class AsciiDocOut :
    OutOptions
{
    public AsciiDocOut(Stream stream) :
        base(stream)
    {
    }

    public AsciiDocOut(string file) :
        base(file)
    {
    }

    public override string Format => "asciidoc";
}