namespace PandocNet;

public class EmacsOrgInput :
    InputOptions
{
    public EmacsOrgInput(Stream stream) :
        base(stream)
    {
    }

    public EmacsOrgInput(string file) :
        base(file)
    {
    }

    public override string Format => "org";
}