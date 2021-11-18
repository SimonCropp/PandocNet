namespace PandocNet;

public class JiraIn :
    InOptions
{
    public JiraIn(Stream stream) :
        base(stream)
    {
    }

    public JiraIn(string file) :
        base(file)
    {
    }

    public override string Format => "jira";
}