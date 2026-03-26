namespace Pandoc;

/// <summary>
/// https://citeproc-js.readthedocs.io/en/latest/csl-json/markup.html
/// </summary>
public class CslJsonIn :
    InOptions
{
    protected override string Format => "csljson";
}
