namespace Pandoc;

/// <summary>
/// https://jira.atlassian.com/secure/WikiRendererHelpAction.jspa?section=all
/// </summary>
public class JiraOut :
    OutOptions
{
    public override string Format => "jira";
}