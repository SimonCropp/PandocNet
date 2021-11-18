namespace PandocNet;

public abstract class BaseMdInput :
    InputOptions
{
    public BaseMdInput(Stream stream) :
        base(stream)
    {
    }

    public BaseMdInput(string file) :
        base(file)
    {
    }

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