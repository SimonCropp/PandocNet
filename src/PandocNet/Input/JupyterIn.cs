namespace Pandoc;

/// <summary>
/// https://nbformat.readthedocs.io/en/latest/
/// </summary>
public class JupyterIn :
    InOptions
{
    protected override string Format => "ipynb";
}