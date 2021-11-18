namespace PandocNet;

public class HaddockOut :
    OutOptions
{
    public HaddockOut(Stream stream) :
        base(stream)
    {
    }

    public HaddockOut(string file) :
        base(file)
    {
    }

    public override string Format => "haddock";
}