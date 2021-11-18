namespace PandocNet;

public class HtmlIn :
    InOptions
{
    public HtmlIn(Stream stream) :
        base(stream)
    {
    }

    public HtmlIn(string file) :
        base(file)
    {
    }

    public override string Format => "html";
}