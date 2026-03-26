namespace Pandoc;

/// <summary>
/// http://opml.org/spec2.opml
/// </summary>
public class OpmlOut :
    OutOptions
{
    public override string Format => "opml";
}