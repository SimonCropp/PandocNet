namespace PandocNet;

public class EpubIn :
    InOptions
{
    public EpubIn(Stream stream) :
        base(stream)
    {
    }

    public EpubIn(string file) :
        base(file)
    {
    }

    public override string Format => "epub";
}