namespace PandocNet;

public class MuseOutput :
    OutputOptions
{
    public MuseOutput(Stream stream) :
        base(stream)
    {
    }

    public MuseOutput(string file) :
        base(file)
    {
    }

    public override string Format => "muse";
}