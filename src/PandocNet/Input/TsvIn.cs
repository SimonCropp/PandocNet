namespace Pandoc;

/// <summary>
/// https://en.wikipedia.org/wiki/Tab-separated_values
/// </summary>
public class TsvIn :
    InOptions
{
    protected override string Format => "tsv";
}
