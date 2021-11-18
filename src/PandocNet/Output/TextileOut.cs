namespace PandocNet;

public class TextileOut :
    OutOptions
{
    public TextileOut(Stream stream) :
        base(stream)
    {
    }

    public TextileOut(string file) :
        base(file)
    {
    }

    public override string Format => "textile";
}