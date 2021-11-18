namespace PandocNet;

public class CommonMarkXInput :
    BaseMdInput
{
    public CommonMarkXInput(Stream stream) :
        base(stream)
    {
    }

    public CommonMarkXInput(string file) :
        base(file)
    {
    }

    public override string Format => "commonmark_x";
}