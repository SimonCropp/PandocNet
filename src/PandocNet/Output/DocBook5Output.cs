namespace PandocNet;

public class DocBook5Output :
    InputOptions
{
    public DocBook5Output(Stream stream) :
        base(stream)
    {
    }

    public DocBook5Output(string file) :
        base(file)
    {
    }

    public override string Format => "docbook5";
}