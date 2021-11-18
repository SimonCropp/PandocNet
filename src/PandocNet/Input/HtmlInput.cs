namespace PandocNet;

public class HtmlInput :
    InputOptions
{
    public HtmlInput(Stream stream) :
        base(stream)
    {
    }

    public HtmlInput(string file) :
        base(file)
    {
    }

    public override string Format => "html";
}