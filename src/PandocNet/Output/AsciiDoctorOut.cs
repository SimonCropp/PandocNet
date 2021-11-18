namespace PandocNet;

public class AsciiDoctorOut :
    OutOptions
{
    public AsciiDoctorOut(Stream stream) :
        base(stream)
    {
    }

    public AsciiDoctorOut(string file) :
        base(file)
    {
    }

    public override string Format => "asciidoctor";
}