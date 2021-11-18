namespace PandocNet;

public class Fb2Out :
    OutOptions
{
    public Fb2Out(Stream stream) :
        base(stream)
    {
    }

    public Fb2Out(string file) :
        base(file)
    {
    }

    public override string Format => "fb2";
}