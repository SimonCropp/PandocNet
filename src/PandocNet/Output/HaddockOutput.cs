namespace PandocNet;

public class HaddockOutput :
    OutputOptions
{
    public HaddockOutput(Stream stream) :
        base(stream)
    {
    }

    public HaddockOutput(string file) :
        base(file)
    {
    }

    public override string Format => "haddock";
}