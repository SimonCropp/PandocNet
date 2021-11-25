namespace Pandoc;

/// <summary>
/// http://www.fictionbook.org/index.php/Eng:XML_Schema_Fictionbook_2.1
/// </summary>
public class Fib2In :
    InOptions
{
    protected override string Format => "fb2";
}