namespace Pandoc;

/// <summary>
/// https://www.gnu.org/software/texinfo/
/// </summary>
public class TexInfoOut :
    OutOptions
{
    public override string Format => "texinfo";
}