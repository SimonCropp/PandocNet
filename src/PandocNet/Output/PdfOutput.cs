namespace PandocNet;

public class PdfOutput :
    OutputOptions
{
    public PdfOutput(Stream stream) :
        base(stream)
    {
    }

    public PdfOutput(string file) :
        base(file)
    {
    }

    public override string Format => "pdf";
}