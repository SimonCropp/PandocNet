namespace PandocNet;

public class TexInfoOut :
    OutOptions
{
    public TexInfoOut(Stream stream) :
        base(stream)
    {
    }

    public TexInfoOut(string file) :
        base(file)
    {
    }

    public override string Format => "texinfo";
}