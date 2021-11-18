namespace PandocNet;

public class TxtOut :
    OutOptions
{
    public TxtOut(Stream stream) :
        base(stream)
    {
    }

    public TxtOut(string file) :
        base(file)
    {
    }

    public override string Format => "plain";
}