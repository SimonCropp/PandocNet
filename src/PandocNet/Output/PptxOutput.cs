namespace PandocNet;

public class PptxOutput :
    OutputOptions
{
    public PptxOutput(Stream stream) :
        base(stream)
    {
    }

    public PptxOutput(string file) :
        base(file)
    {
    }

    public override string Format => "pptx";
}