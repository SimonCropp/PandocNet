namespace Pandoc;

/// <summary>
/// https://www.latex-project.org/
/// </summary>
public class LaTexIn :
    InOptions
{
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

    protected override string Format => "latex";
}