namespace PandocNet;

public class CslJsonOutput :
    InputOptions
{
    public CslJsonOutput(Stream stream) :
        base(stream)
    {
    }

    public CslJsonOutput(string file) :
        base(file)
    {
    }

    public override string Format => "csljson";
}