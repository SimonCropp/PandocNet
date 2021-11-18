namespace PandocNet;

public class S5Output :
    OutputOptions
{
    public S5Output(Stream stream) :
        base(stream)
    {
    }

    public S5Output(string file) :
        base(file)
    {
    }

    public override string Format => "s5";
}