namespace PandocNet;

public class JatsIn :
    InOptions
{
    public JatsIn(Stream stream) :
        base(stream)
    {
    }

    public JatsIn(string file) :
        base(file)
    {
    }

    public override string Format => "jats";
}