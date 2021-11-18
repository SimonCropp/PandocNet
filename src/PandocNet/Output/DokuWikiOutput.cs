namespace PandocNet;

public class DokuWikiOutput :
    OutputOptions
{
    public DokuWikiOutput(Stream stream) :
        base(stream)
    {
    }

    public DokuWikiOutput(string file) :
        base(file)
    {
    }

    public override string Format => "dokuwiki";
}