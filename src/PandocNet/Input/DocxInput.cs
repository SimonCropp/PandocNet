namespace PandocNet;

public class DocxInput :
    InputOptions
{
    public DocxInput(Stream stream) :
        base(stream)
    {
    }

    public DocxInput(string file) :
        base(file)
    {
    }

    public override string Format => "docx";
}