namespace PandocNet;

public class DocBookInput :
    InputOptions
{
    public DocBookInput(Stream stream) :
        base(stream)
    {
    }

    public DocBookInput(string file) :
        base(file)
    {
    }

    public override string Format => "docbook";
}