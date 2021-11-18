namespace PandocNet;

public class JiraOutput :
    OutputOptions
{
    public JiraOutput(Stream stream) :
        base(stream)
    {
    }

    public JiraOutput(string file) :
        base(file)
    {
    }

    public override string Format => "jira";
}