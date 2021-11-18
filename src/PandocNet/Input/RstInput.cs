namespace PandocNet;

public class RstInput :
    InputOptions
{
    public RstInput(Stream stream) :
        base(stream)
    {
    }

    public RstInput(string file) :
        base(file)
    {
    }

    public override string Format => "rst";
}