namespace PandocNet;

public class Epub2Output :
    OutputOptions
{
    public Epub2Output(Stream stream) :
        base(stream)
    {
    }

    public Epub2Output(string file) :
        base(file)
    {
    }

    public override string Format => "epub2";
}