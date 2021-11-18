namespace PandocNet;

public class DocBookIn :
    InOptions
{
    public DocBookIn(Stream stream) :
        base(stream)
    {
    }

    public DocBookIn(string file) :
        base(file)
    {
    }

    public override string Format => "docbook";
}