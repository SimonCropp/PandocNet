namespace PandocNet;

public class HaddockIn :
    InOptions
{
    public HaddockIn(Stream stream) :
        base(stream)
    {
    }

    public HaddockIn(string file) :
        base(file)
    {
    }

    public override string Format => "haddock";
}