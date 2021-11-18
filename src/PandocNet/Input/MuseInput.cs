namespace PandocNet;

public class MuseInput :
    InputOptions
{
    public MuseInput(Stream stream) :
        base(stream)
    {
    }

    public MuseInput(string file) :
        base(file)
    {
    }

    public override string Format => "muse";
}