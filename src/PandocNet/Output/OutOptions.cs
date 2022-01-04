using System.Runtime.InteropServices;

namespace Pandoc;

public abstract class OutOptions
{
    public abstract string Format { get; }

    public bool Standalone { get; set; }
    public bool StripComments { get; set; }
    public bool NoHighlight { get; set; }
    public bool NoCheckCertificate { get; set; }
    public string? HighlightStyle { get; set; }
    public string? SyntaxDefinition { get; set; }
    public string? IncludeInHeader { get; set; }
    public string? IncludeBeforeBody { get; set; }
    public string? IncludeAfterBody { get; set; }
    public IList<string>? ResourcePaths { get; set; }
    public bool Sandbox { get; set; }
    public bool TableOfContents { get; set; }
    public int? TableOfContentsDepth { get; set; }
    public Eol? Eol { get; set; }
    public Wrap? Wrap { get; set; }
    public int? Dpi { get; set; }
    public int? Columns { get; set; }
    public string? Template { get; set; }

    //TODO: variables
    public virtual IEnumerable<string> GetArguments()
    {
        yield return $"--to={Format}";

        if (Standalone)
        {
            yield return "--standalone";
        }

        if (Template != null)
        {
            yield return $"--template={Template}";
        }

        if (Sandbox)
        {
            yield return "--sandbox";
        }

        if (Eol != null)
        {
            yield return $"--eol={Eol.Value.ToString().ToLower()}";
        }

        if (Wrap != null)
        {
            yield return $"--wrap=={Wrap.Value.ToString().ToLower()}";
        }

        if (Dpi != null)
        {
            yield return $"--dpi={Dpi}";
        }
        if (Columns != null)
        {
            yield return $"--columns={Columns}";
        }
        if (TableOfContents)
        {
            yield return "--table-of-contents";
        }
        if (TableOfContentsDepth != null)
        {
            yield return $"--toc-depth={TableOfContentsDepth}";
        }
        if (StripComments)
        {
            yield return "--strip-comments";
        }
        if (NoHighlight)
        {
            yield return "--no-highlight";
        }
        if (NoCheckCertificate)
        {
            yield return "--no-check-certificate";
        }
        if (HighlightStyle != null)
        {
            yield return $"--highlight-style={HighlightStyle}";
        }
        if (SyntaxDefinition != null)
        {
            yield return $"--syntax-definition={SyntaxDefinition}";
        }
        if (IncludeInHeader != null)
        {
            yield return $"--include-in-header={IncludeInHeader}";
        }
        if (IncludeBeforeBody != null)
        {
            yield return $"--include-before-body={IncludeBeforeBody}";
        }
        if (IncludeAfterBody != null)
        {
            yield return $"--include-after-body={IncludeAfterBody}";
        }
        //TODO: request-header

        if (ResourcePaths != null)
        {
            var split = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? ";" : ":";
            yield return $"--resource-path={string.Join(split, ResourcePaths)}";
        }
    }
}