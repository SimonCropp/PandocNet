namespace PandocNet;

public class SlidyOutput :
    OutputOptions
{
    public SlidyOutput(Stream stream) :
        base(stream)
    {
    }

    public SlidyOutput(string file) :
        base(file)
    {
    }

    public override string Format => "slidy";
}