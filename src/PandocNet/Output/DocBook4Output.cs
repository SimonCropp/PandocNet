namespace PandocNet;

public class DocBook4Output :
    OutputOptions
{
    public DocBook4Output(Stream stream) :
        base(stream)
    {
    }

    public DocBook4Output(string file) :
        base(file)
    {
    }

    public override string Format => "docbook4";

    //https://pandoc.org/MANUAL.html#options-affecting-specific-writers
    public TopLevelDivision? TopLevelDivision { get; set; }
    public string? IdPrefix { get; set; }

    public override IEnumerable<string> GetArguments()
    {
        foreach (var argument in base.GetArguments())
        {
            yield return argument;
        }

        if (IdPrefix != null)
        {
            yield return $"--id-prefix={IdPrefix}";
        }

        if (TopLevelDivision != null)
        {
            yield return $"--top-level-division={TopLevelDivision}";
        }
    }
}