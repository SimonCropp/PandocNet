namespace PandocNet;

public class TextileIn :
    InOptions
{
    public TextileIn(Stream stream) :
        base(stream)
    {
    }

    public TextileIn(string file) :
        base(file)
    {
    }

    public override string Format => "textile";
}