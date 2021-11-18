namespace PandocNet;

public class JatsArchivingOutput :
    OutputOptions
{
    public JatsArchivingOutput(Stream stream) :
        base(stream)
    {
    }

    public JatsArchivingOutput(string file) :
        base(file)
    {
    }

    public override string Format => "jats_archiving";
}