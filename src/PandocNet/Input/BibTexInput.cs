namespace PandocNet;

public class BibTexInput :
    InputOptions
{
    public BibTexInput(Stream stream) :
        base(stream)
    {
    }

    public BibTexInput(string file) :
        base(file)
    {
    }

    public override string Format => "bibtex";
}