namespace PandocNet;

public class BibTexIn :
    InOptions
{
    public BibTexIn(Stream stream) :
        base(stream)
    {
    }

    public BibTexIn(string file) :
        base(file)
    {
    }

    public override string Format => "bibtex";
}