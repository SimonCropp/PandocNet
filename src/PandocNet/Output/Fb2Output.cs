namespace PandocNet;

public class Fb2Output :
    OutputOptions
{
    public Fb2Output(Stream stream) :
        base(stream)
    {
    }

    public Fb2Output(string file) :
        base(file)
    {
    }

    public override string Format => "fb2";
}