namespace PandocNet;

public class BibLaTeXOutput :
    OutputOptions
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