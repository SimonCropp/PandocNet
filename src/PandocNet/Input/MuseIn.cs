namespace PandocNet;

public class MuseIn :
    InOptions
{
    public MuseIn(Stream stream) :
        base(stream)
    {
    }

    public MuseIn(string file) :
        base(file)
    {
    }

    public override string Format => "muse";
}