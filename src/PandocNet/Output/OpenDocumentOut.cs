namespace PandocNet;

public class OpenDocumentOut :
    OutOptions
{
    public OpenDocumentOut(Stream stream) :
        base(stream)
    {
    }

    public OpenDocumentOut(string file) :
        base(file)
    {
    }

    public override string Format => "opendocument";
}