namespace PandocNet;

public class DokuWikiIn :
    InOptions
{
    public DokuWikiIn(Stream stream) :
        base(stream)
    {
    }

    public DokuWikiIn(string file) :
        base(file)
    {
    }

    public override string Format => "dokuwiki";
}