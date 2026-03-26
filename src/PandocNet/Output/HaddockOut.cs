namespace Pandoc;

/// <summary>
/// https://haskell-haddock.readthedocs.io/
/// </summary>
public class HaddockOut :
    OutOptions
{
    public override string Format => "haddock";
}