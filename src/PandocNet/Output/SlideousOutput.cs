namespace PandocNet;

public class SlideousOutput :
    OutputOptions
{
    public SlideousOutput(Stream stream) :
        base(stream)
    {
    }

    public SlideousOutput(string file) :
        base(file)
    {
    }

    public override string Format => "slideous";
}