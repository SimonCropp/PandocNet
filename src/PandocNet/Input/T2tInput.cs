namespace PandocNet;

public class T2tInput :
    InputOptions
{
    public T2tInput(Stream stream) :
        base(stream)
    {
    }

    public T2tInput(string file) :
        base(file)
    {
    }

    public override string Format => "t2t";
}