namespace PandocNet;

public class TxtOutput :
    OutputOptions
{
    public TxtOutput(Stream stream) :
        base(stream)
    {
    }

    public TxtOutput(string file) :
        base(file)
    {
    }

    public override string Format => "plain";
}