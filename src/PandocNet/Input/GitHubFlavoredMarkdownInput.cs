namespace PandocNet;

public class GitHubFlavoredMarkdownInput :
    InputOptions
{
    public GitHubFlavoredMarkdownInput(Stream stream) :
        base(stream)
    {
    }

    public GitHubFlavoredMarkdownInput(string file) :
        base(file)
    {
    }

    public override string Format => "gfm";
}