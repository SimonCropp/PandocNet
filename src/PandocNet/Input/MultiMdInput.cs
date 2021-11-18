namespace PandocNet;

public class MultiMdInput :
    BaseMdInput
{
    public MultiMdInput(Stream stream) :
        base(stream)
    {
    }

    public MultiMdInput(string file) :
        base(file)
    {
    }

    public override string Format => "markdown_mmd";
}