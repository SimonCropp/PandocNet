namespace PandocNet;

public class CreoleInput :
    InputOptions
{
    public CreoleInput(Stream stream) :
        base(stream)
    {
    }

    public CreoleInput(string file) :
        base(file)
    {
    }

    public override string Format => "creole";
}