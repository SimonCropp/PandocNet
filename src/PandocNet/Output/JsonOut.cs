namespace PandocNet;

public class JsonOut :
    OutOptions
{
    public JsonOut(Stream stream) :
        base(stream)
    {
    }

    public JsonOut(string file) :
        base(file)
    {
    }

    public override string Format => "json";
}