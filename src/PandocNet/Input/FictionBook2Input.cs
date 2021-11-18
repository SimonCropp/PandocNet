namespace PandocNet;

public class FictionBook2Input :
    InputOptions
{
    public FictionBook2Input(Stream stream) :
        base(stream)
    {
    }

    public FictionBook2Input(string file) :
        base(file)
    {
    }

    public override string Format => "fb2";
}