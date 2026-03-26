namespace Pandoc;

/// <summary>
/// https://haskell-haddock.readthedocs.io/
/// </summary>
public class HaddockIn :
    InOptions
{
    protected override string Format => "haddock";
}