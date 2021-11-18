namespace PandocNet;

public class T2tIn :
    InOptions
{
    public T2tIn(Stream stream) :
        base(stream)
    {
    }

    public T2tIn(string file) :
        base(file)
    {
    }

    public override string Format => "t2t";
}