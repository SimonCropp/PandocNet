namespace PandocNet;

public class VimWikiInput :
    InputOptions
{
    public VimWikiInput(Stream stream) :
        base(stream)
    {
    }

    public VimWikiInput(string file) :
        base(file)
    {
    }

    public override string Format => "vimwiki";
}