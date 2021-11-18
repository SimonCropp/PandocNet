namespace PandocNet;

public class DokuWikiInput :
    InputOptions
{
    public DokuWikiInput(Stream stream) :
        base(stream)
    {
    }

    public DokuWikiInput(string file) :
        base(file)
    {
    }

    public override string Format => "dokuwiki";
}