namespace PandocNet;

public class OdtIn :
    InOptions
{
    public OdtIn(Stream stream) :
        base(stream)
    {
    }

    public OdtIn(string file) :
        base(file)
    {
    }

    public override string Format => "odt";
}