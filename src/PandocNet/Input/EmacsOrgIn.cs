namespace PandocNet;

public class EmacsOrgIn :
    InOptions
{
    public EmacsOrgIn(Stream stream) :
        base(stream)
    {
    }

    public EmacsOrgIn(string file) :
        base(file)
    {
    }

    public override string Format => "org";
}