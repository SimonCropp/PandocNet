namespace Pandoc;

/// <summary>
/// Determine how text is wrapped in the output (the source code, not the rendered version).
/// https://pandoc.org/MANUAL.html#option--wrap
/// </summary>
public enum Wrap
{
    Auto,
    None,
    Preserve
}