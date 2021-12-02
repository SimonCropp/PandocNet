namespace Pandoc;

/// <summary>
/// https://man.cx/groff_man(7)
/// </summary>
public class RoffManOut :
    OutOptions
{
    public override string Format => "man";
}