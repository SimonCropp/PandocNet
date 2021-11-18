namespace PandocNet;

public class TikiWikiInput :
    InputOptions
{
    public TikiWikiInput(Stream stream) :
        base(stream)
    {
    }

    public TikiWikiInput(string file) :
        base(file)
    {
    }

    public override string Format => "tikiwiki";
}