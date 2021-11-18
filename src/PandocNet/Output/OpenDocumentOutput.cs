namespace PandocNet;

public class OpenDocumentOutput :
    OutputOptions
{
    public OpenDocumentOutput(Stream stream) :
        base(stream)
    {
    }

    public OpenDocumentOutput(string file) :
        base(file)
    {
    }

    public override string Format => "opendocument";
}