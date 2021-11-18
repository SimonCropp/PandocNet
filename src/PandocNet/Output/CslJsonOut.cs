namespace PandocNet;

public class CslJsonOut :
    OutOptions
{
    public CslJsonOut(Stream stream) :
        base(stream)
    {
    }

    public CslJsonOut(string file) :
        base(file)
    {
    }

    public override string Format => "csljson";
}