namespace PandocNet;

public class TextileInput :
    InputOptions
{
    public TextileInput(Stream stream) :
        base(stream)
    {
    }

    public TextileInput(string file) :
        base(file)
    {
    }

    public override string Format => "textile";
}