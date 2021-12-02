namespace Pandoc;

/// <summary>
/// https://www.haskell.org/haddock/doc/html/ch03s08.html
/// </summary>
public class HaddockIn :
    InOptions
{
    protected override string Format => "haddock";
}