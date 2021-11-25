namespace Pandoc;

/// <summary>
/// https://michelf.ca/projects/php-markdown/extra/
/// </summary>
public class PhpMdExtraIn :
    InOptions
{
    protected override string Format => "markdown_phpextra";

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