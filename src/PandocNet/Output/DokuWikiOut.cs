namespace PandocNet;

public class DokuWikiOut :
    OutOptions
{
    public DokuWikiOut(Stream stream) :
        base(stream)
    {
    }

    public DokuWikiOut(string file) :
        base(file)
    {
    }

    public override string Format => "dokuwiki";
}