namespace PandocNet;

public class JsonIn :
    InOptions
{
    public JsonIn(Stream stream) :
        base(stream)
    {
    }

    public JsonIn(string file) :
        base(file)
    {
    }

    public override string Format => "json";
}