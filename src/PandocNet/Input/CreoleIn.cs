namespace PandocNet;

public class CreoleIn :
    InOptions
{
    public CreoleIn(Stream stream) :
        base(stream)
    {
    }

    public CreoleIn(string file) :
        base(file)
    {
    }

    public override string Format => "creole";
}