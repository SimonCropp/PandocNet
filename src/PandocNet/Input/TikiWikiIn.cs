namespace PandocNet;

public class TikiWikiIn :
    InOptions
{
    public TikiWikiIn(Stream stream) :
        base(stream)
    {
    }

    public TikiWikiIn(string file) :
        base(file)
    {
    }

    public override string Format => "tikiwiki";
}