namespace PandocNet;

public class JsonInput :
    InputOptions
{
    public JsonInput(Stream stream) :
        base(stream)
    {
    }

    public JsonInput(string file) :
        base(file)
    {
    }

    public override string Format => "json";
}