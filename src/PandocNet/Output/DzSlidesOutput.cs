namespace PandocNet;

public class DzSlidesOutput :
    OutputOptions
{
    public DzSlidesOutput(Stream stream) :
        base(stream)
    {
    }

    public DzSlidesOutput(string file) :
        base(file)
    {
    }

    public override string Format => "dzslides";
}