namespace PandocNet;

public class BibTeXOut :
    OutOptions
{
    public BibTeXOut(Stream stream) :
        base(stream)
    {
    }

    public BibTeXOut(string file) :
        base(file)
    {
    }

    public override string Format => "bibtex";
}