namespace Pandoc;

/// <summary>
/// https://docutils.sourceforge.io/docs/ref/rst/introduction.html
/// </summary>
public class RstIn :
    InOptions
{
    protected override string Format => "rst";
}