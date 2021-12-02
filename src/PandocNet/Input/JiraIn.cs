namespace Pandoc;

/// <summary>
/// https://jira.atlassian.com/secure/WikiRendererHelpAction.jspa?section=all
/// </summary>
public class JiraIn :
    InOptions
{
    protected override string Format => "jira";
}