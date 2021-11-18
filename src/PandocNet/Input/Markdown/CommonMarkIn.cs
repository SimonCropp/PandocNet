namespace PandocNet;

public class CommonMarkIn :
    InOptions
{
    public CommonMarkIn(Stream stream) :
        base(stream)
    {
    }

    public CommonMarkIn(string file) :
        base(file)
    {
    }

    public override string Format => "commonmark";
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