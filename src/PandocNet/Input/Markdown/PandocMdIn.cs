namespace Pandoc;

/// <summary>
/// https://pandoc.org/MANUAL.html#pandocs-markdown
/// </summary>
public class PandocMdIn :
    InOptions
{
    protected override string Format => "markdown";

    /// <summary>
    /// Specify a default extension to use when image paths/URLs have no extension
    /// https://pandoc.org/MANUAL.html#option--default-image-extension
    /// </summary>
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