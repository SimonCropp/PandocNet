namespace PandocNet;

public class TWikiIn :
    InOptions
{
    public TWikiIn(Stream stream) :
        base(stream)
    {
    }

    public TWikiIn(string file) :
        base(file)
    {
    }

    public override string Format => "twiki";
}