namespace PandocNet;

public class BibLaTeXInput :
    InputOptions
{
    public BibLaTeXInput(Stream stream) :
        base(stream)
    {
    }

    public BibLaTeXInput(string file) :
        base(file)
    {
    }

    public override string Format => "biblatex";
}