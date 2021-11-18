namespace PandocNet;

public class OdtInput :
    InputOptions
{
    public OdtInput(Stream stream) :
        base(stream)
    {
    }

    public OdtInput(string file) :
        base(file)
    {
    }

    public override string Format => "odt";
}