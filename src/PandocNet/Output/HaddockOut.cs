namespace Pandoc;

/// <summary>
/// https://www.haskell.org/haddock/doc/html/ch03s08.html
/// </summary>
public class HaddockOut :
    OutOptions
{
    public override string Format => "haddock";
}