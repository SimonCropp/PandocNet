namespace PandocNet;

public class BibTeXOutput :
    InputOptions
{
    public BibTeXOutput(Stream stream) :
        base(stream)
    {
    }

    public BibTeXOutput(string file) :
        base(file)
    {
    }

    public override string Format => "bibtex";
}