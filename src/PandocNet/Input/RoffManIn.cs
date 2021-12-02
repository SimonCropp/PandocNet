namespace Pandoc;

/// <summary>
/// https://man.cx/groff_man(7)
/// </summary>
public class RoffManIn :
    InOptions
{
    protected override string Format => "man";
}