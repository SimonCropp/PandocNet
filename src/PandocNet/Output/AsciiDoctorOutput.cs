namespace PandocNet;

public class AsciiDoctorOutput :
    InputOptions
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