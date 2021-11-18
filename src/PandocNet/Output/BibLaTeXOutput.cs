namespace PandocNet;

public class BibLaTeXOutput :
    InputOptions
{
    public BibLaTeXOutput(Stream stream) :
        base(stream)
    {
    }

    public BibLaTeXOutput(string file) :
        base(file)
    {
    }

    public override string Format => "biblatex";
}