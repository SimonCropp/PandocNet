namespace PandocNet;

public class HaddockInput :
    InputOptions
{
    public HaddockInput(Stream stream) :
        base(stream)
    {
    }

    public HaddockInput(string file) :
        base(file)
    {
    }

    public override string Format => "haddock";
}