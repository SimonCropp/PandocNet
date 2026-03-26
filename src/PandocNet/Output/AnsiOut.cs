namespace Pandoc;

/// <summary>
/// ANSI terminal output.
/// </summary>
public class AnsiOut :
    OutOptions
{
    public override string Format => "ansi";
}
