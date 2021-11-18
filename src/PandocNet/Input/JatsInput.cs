namespace PandocNet;

public class JatsInput :
    InputOptions
{
    public JatsInput(Stream stream) :
        base(stream)
    {
    }

    public JatsInput(string file) :
        base(file)
    {
    }

    public override string Format => "jats";
}