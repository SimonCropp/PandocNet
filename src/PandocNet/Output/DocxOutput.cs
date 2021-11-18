namespace PandocNet;

public class DocxOutput :
    OutputOptions
{
    public DocxOutput(Stream stream) :
        base(stream)
    {
    }

    public DocxOutput(string file) :
        base(file)
    {
    }

    public override string Format => "docx";
}