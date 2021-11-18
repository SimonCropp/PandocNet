namespace PandocNet;

public class CommonMarkInput :
    InputOptions
{
    public CommonMarkInput(Stream stream) :
        base(stream)
    {
    }

    public CommonMarkInput(string file) :
        base(file)
    {
    }

    public override string Format => "commonmark";
}