namespace PandocNet;

public class JiraInput :
    InputOptions
{
    public JiraInput(Stream stream) :
        base(stream)
    {
    }

    public JiraInput(string file) :
        base(file)
    {
    }

    public override string Format => "jira";
}