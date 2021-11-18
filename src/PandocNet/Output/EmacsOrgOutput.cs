namespace PandocNet;

public class EmacsOrgOutput :
    OutputOptions
{
    public EmacsOrgOutput(Stream stream) :
        base(stream)
    {
    }

    public EmacsOrgOutput(string file) :
        base(file)
    {
    }

    public override string Format => "org";
}