namespace PandocNet;

public class Epub3Output :
    OutputOptions
{
    public Epub3Output(Stream stream) :
        base(stream)
    {
    }

    public Epub3Output(string file) :
        base(file)
    {
    }

    public override string Format => "epub3";
}