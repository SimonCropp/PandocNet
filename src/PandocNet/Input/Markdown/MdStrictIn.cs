namespace Pandoc;

/// <summary>
/// https://daringfireball.net/projects/markdown/
/// </summary>
public class MdStrictIn :
    InOptions
{
    protected override string Format => "markdown_strict";

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