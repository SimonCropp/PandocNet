namespace Pandoc;

/// <summary>
/// https://amusewiki.org/library/manual
/// </summary>
public class MuseOut :
    OutOptions
{
    public override string Format => "muse";

    /// <summary>
    /// Specify whether footnotes (and references, if reference-links is set) are placed at the end of the current (top-level) block, the current section, or the document.
    /// https://pandoc.org/MANUAL.html#option--reference-location
    /// </summary>
    public ReferenceLocation? ReferenceLocation { get; set; }

    public override IEnumerable<string> GetArguments()
    {
        foreach (var argument in base.GetArguments())
        {
            yield return argument;
        }

        if (ReferenceLocation != null)
        {
            yield return $"--reference-location={ReferenceLocation}";
        }
    }
}