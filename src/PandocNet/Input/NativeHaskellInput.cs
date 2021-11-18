namespace PandocNet;

public class NativeHaskellInput :
    InputOptions
{
    public NativeHaskellInput(Stream stream) :
        base(stream)
    {
    }

    public NativeHaskellInput(string file) :
        base(file)
    {
    }

    public override string Format => "native ";
}