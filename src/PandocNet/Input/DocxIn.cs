namespace PandocNet;

public class DocxIn :
    InOptions
{
    public DocxIn(Stream stream) :
        base(stream)
    {
    }

    public DocxIn(string file) :
        base(file)
    {
    }

    public override string Format => "docx";
}