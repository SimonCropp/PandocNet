namespace PandocNet;

public class MdStrictIn :
    InOptions
{
    public MdStrictIn(Stream stream) :
        base(stream)
    {
    }

    public MdStrictIn(string file) :
        base(file)
    {
    }

    public override string Format => "markdown_strict";
    //https://pandoc.org/MANUAL.html#reader-options
    public string? DefaultImageExtension { get; set; }

    public override IEnumerable<string> GetArguments()
    {
        foreach (var argument in base.GetArguments())
        {
            yield return argument;
        }

        if (DefaultImageExtension != null)
        {
            yield return $"--default-image-extension={DefaultImageExtension}";
        }
    }
}