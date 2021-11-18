namespace PandocNet;

public class AsciiDocOutput :
    OutputOptions
{
    public AsciiDocOutput(Stream stream) :
        base(stream)
    {
    }

    public AsciiDocOutput(string file) :
        base(file)
    {
    }

    public override string Format => "asciidoc";
}