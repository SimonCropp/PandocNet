namespace PandocNet;

public class AsciiDoctorOutput :
    OutputOptions
{
    public AsciiDoctorOutput(Stream stream) :
        base(stream)
    {
    }

    public AsciiDoctorOutput(string file) :
        base(file)
    {
    }

    public override string Format => "asciidoctor";
}