namespace PandocNet;

public class RevealJsOut :
    OutOptions
{
    public RevealJsOut(Stream stream) :
        base(stream)
    {
    }

    public RevealJsOut(string file) :
        base(file)
    {
    }

    public override string Format => "revealjs";

    //https://pandoc.org/MANUAL.html#options-affecting-specific-writers
    public bool SelfContained { get; set; }
    public bool HtmlQTags { get; set; }
    public bool SectionDivs { get; set; }
    public bool Ascii { get; set; }
    public ReferenceLocation? ReferenceLocation { get; set; }
    public string? IdPrefix { get; set; }
    public string? Css { get; set; }
    public string? TitlePrefix { get; set; }

    public override IEnumerable<string> GetArguments()
    {
        foreach (var argument in base.GetArguments())
        {
            yield return argument;
        }

        if (SelfContained)
        {
            yield return "--self-contained";
        }

        if (Ascii)
        {
            yield return "--ascii";
        }

        if (HtmlQTags)
        {
            yield return "--html-q-tags";
        }
        if (SectionDivs)
        {
            yield return "--section-divs";
        }
        if (ReferenceLocation != null)
        {
            yield return $"--reference-location={ReferenceLocation}";
        }
        if (IdPrefix != null)
        {
            yield return $"--id-prefix={IdPrefix}";
        }
        if (Css != null)
        {
            yield return $"--css={Css}";
        }
        if (TitlePrefix != null)
        {
            yield return $"--title-prefix={TitlePrefix}";
        }
    }
}