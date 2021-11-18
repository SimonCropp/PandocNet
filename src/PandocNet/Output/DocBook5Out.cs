namespace PandocNet;

public class DocBook5Out :
    OutOptions
{
    public override string Format => "docbook5";
    
    public TopLevelDivision? TopLevelDivision { get; set; }
    public string? IdPrefix { get; set; }

    public override IEnumerable<string> GetArguments()
    {
        foreach (var argument in base.GetArguments())
        {
            yield return argument;
        }

        if (TopLevelDivision != null)
        {
            yield return $"--top-level-division={TopLevelDivision}";
        }
        if (IdPrefix != null)
        {
            yield return $"--id-prefix={IdPrefix}";
        }
    }
}