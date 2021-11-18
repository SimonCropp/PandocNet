namespace PandocNet;

public class JiraOut :
    OutOptions
{
    public JiraOut(Stream stream) :
        base(stream)
    {
    }

    public JiraOut(string file) :
        base(file)
    {
    }

    public override string Format => "jira";
}