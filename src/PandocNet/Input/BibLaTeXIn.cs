namespace PandocNet;

public class BibLaTeXIn :
    InOptions
{
    public BibLaTeXIn(Stream stream) :
        base(stream)
    {
    }

    public BibLaTeXIn(string file) :
        base(file)
    {
    }

    public override string Format => "biblatex";
}