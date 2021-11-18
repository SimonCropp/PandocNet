namespace PandocNet;

public class HaskellIn :
    InOptions
{
    public HaskellIn(Stream stream) :
        base(stream)
    {
    }

    public HaskellIn(string file) :
        base(file)
    {
    }

    public override string Format => "native ";
}