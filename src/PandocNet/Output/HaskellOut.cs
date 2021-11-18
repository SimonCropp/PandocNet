namespace PandocNet;

public class HaskellOut :
    OutOptions
{
    public HaskellOut(Stream stream) :
        base(stream)
    {
    }

    public HaskellOut(string file) :
        base(file)
    {
    }

    public override string Format => "native";
}