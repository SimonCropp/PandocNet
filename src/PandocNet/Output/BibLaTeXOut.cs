namespace PandocNet;

public class BibLaTeXOut :
    OutOptions
{
    public BibLaTeXOut(Stream stream) :
        base(stream)
    {
    }

    public BibLaTeXOut(string file) :
        base(file)
    {
    }

    public override string Format => "biblatex";
}