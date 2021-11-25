namespace Pandoc;

/// <summary>
/// http://dev.opml.org/spec2.html
/// </summary>
public class OpmlOut :
    OutOptions
{
    public override string Format => "opml";
}