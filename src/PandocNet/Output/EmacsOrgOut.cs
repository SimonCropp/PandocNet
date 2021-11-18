namespace PandocNet;

public class EmacsOrgOut :
    OutOptions
{
    public EmacsOrgOut(Stream stream) :
        base(stream)
    {
    }

    public EmacsOrgOut(string file) :
        base(file)
    {
    }

    public override string Format => "org";
}