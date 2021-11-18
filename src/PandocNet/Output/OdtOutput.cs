namespace PandocNet;

public class OdtOutput :
    OutputOptions
{
    public OdtOutput(Stream stream) :
        base(stream)
    {
    }

    public OdtOutput(string file) :
        base(file)
    {
    }

    public override string Format => "odt";
}