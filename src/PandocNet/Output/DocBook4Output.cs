namespace PandocNet;

public class DocBook4Output :
    OutputOptions
{
    public DocBook4Output(Stream stream) :
        base(stream)
    {
    }

    public DocBook4Output(string file) :
        base(file)
    {
    }

    public override string Format => "docbook4";
}