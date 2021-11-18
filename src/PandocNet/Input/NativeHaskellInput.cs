namespace PandocNet;

public class HaskellInput :
    InputOptions
{
    public HaskellInput(Stream stream) :
        base(stream)
    {
    }

    public HaskellInput(string file) :
        base(file)
    {
    }

    public override string Format => "native ";
}