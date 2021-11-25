namespace Pandoc;

/// <summary>
/// https://citeproc-js.readthedocs.io/en/latest/csl-json/markup.html
/// </summary>
public class CslJsonOut :
    OutOptions
{
    public override string Format => "csljson";
}