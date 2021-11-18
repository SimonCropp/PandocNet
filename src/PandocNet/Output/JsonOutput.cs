namespace PandocNet;

public class JsonOutput :
    OutputOptions
{
    public JsonOutput(Stream stream) :
        base(stream)
    {
    }

    public JsonOutput(string file) :
        base(file)
    {
    }

    public override string Format => "json";
}