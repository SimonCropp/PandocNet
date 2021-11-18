namespace PandocNet;

public class HaskellOutput :
    OutputOptions
{
    public HaskellOutput(Stream stream) :
        base(stream)
    {
    }

    public HaskellOutput(string file) :
        base(file)
    {
    }

    public override string Format => "native";
}