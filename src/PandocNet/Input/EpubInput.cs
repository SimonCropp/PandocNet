namespace PandocNet;

public class EpubInput :
    InputOptions
{
    public EpubInput(Stream stream) :
        base(stream)
    {
    }

    public EpubInput(string file) :
        base(file)
    {
    }

    public override string Format => "epub";
}