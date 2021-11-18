namespace PandocNet;

public class TWikiInput :
    InputOptions
{
    public TWikiInput(Stream stream) :
        base(stream)
    {
    }

    public TWikiInput(string file) :
        base(file)
    {
    }

    public override string Format => "twiki";
}