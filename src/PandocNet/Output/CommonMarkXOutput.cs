namespace PandocNet;

public class CommonMarkXOutput :
    OutputOptions
{
    public CommonMarkXOutput(Stream stream) :
        base(stream)
    {
    }

    public CommonMarkXOutput(string file) :
        base(file)
    {
    }

    public override string Format => "commonmark_x";
}