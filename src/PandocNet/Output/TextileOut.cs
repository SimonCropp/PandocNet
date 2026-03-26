namespace Pandoc;

/// <summary>
/// https://en.wikipedia.org/wiki/Textile_(markup_language)
/// </summary>
public class TextileOut :
    OutOptions
{
    public override string Format => "textile";
}