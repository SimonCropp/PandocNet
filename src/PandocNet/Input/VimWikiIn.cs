namespace PandocNet;

public class VimWikiIn :
    InOptions
{
    public VimWikiIn(Stream stream) :
        base(stream)
    {
    }

    public VimWikiIn(string file) :
        base(file)
    {
    }

    public override string Format => "vimwiki";
}