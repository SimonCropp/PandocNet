namespace PandocNet;

public class HtmlOutput :
    OutputOptions
{
    public HtmlOutput(Stream stream) :
        base(stream)
    {
    }

    public HtmlOutput(string file) :
        base(file)
    {
    }

    public override string Format => "html";
}