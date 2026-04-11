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

    /// <summary>
    /// Process citations using pandoc's built-in citeproc.
    /// https://pandoc.org/MANUAL.html#option--citeproc
    /// </summary>
    public bool Citeproc { get; set; }
    /// <summary>
    /// Set the bibliography field in the document's metadata to the specified file.
    /// https://pandoc.org/MANUAL.html#option--bibliography
    /// </summary>
    public string? Bibliography { get; set; }
    /// <summary>
    /// Set the csl field in the document's metadata to the specified file.
    /// https://pandoc.org/MANUAL.html#option--csl
    /// </summary>
    public string? Csl { get; set; }
    /// <summary>
    /// Set the citation-abbreviations field in the document's metadata to the specified file.
    /// https://pandoc.org/MANUAL.html#option--citation-abbreviations
    /// </summary>
    public string? CitationAbbreviations { get; set; }

    /// <summary>
    /// Render math using MathML.
    /// https://pandoc.org/MANUAL.html#option--mathml
    /// </summary>
    public bool MathMl { get; set; }
    /// <summary>
    /// Render math using a linked script from the specified URL. If no URL is provided, the default MathJax URL will be used.
    /// https://pandoc.org/MANUAL.html#option--mathjax
    /// </summary>
    public string? MathJax { get; set; }
    /// <summary>
    /// Render math using a linked script from the specified URL. If no URL is provided, the default KaTeX URL will be used.
    /// https://pandoc.org/MANUAL.html#option--katex
    /// </summary>
    public string? KaTeX { get; set; }
    /// <summary>
    /// Render formulas as images using the specified URL. If no URL is provided, the default WebTeX URL will be used.
    /// https://pandoc.org/MANUAL.html#option--webtex
    /// </summary>
    public string? WebTeX { get; set; }
    /// <summary>
    /// Enclose TeX math in &lt;eq&gt; tags in HTML output for processing by GladTeX.
    /// https://pandoc.org/MANUAL.html#option--gladtex
    /// </summary>
    public bool GladTeX { get; set; }

    /// <summary>
    /// Set template variable KEY to the value VAL when rendering the document in standalone mode.
    /// https://pandoc.org/MANUAL.html#option--variable
    /// </summary>
    public IDictionary<string, string>? Variables { get; set; }

    /// <summary>
    /// Set template variable KEY to a JSON value. Unlike --variable, this replaces rather than appends.
    /// https://pandoc.org/MANUAL.html#option--variable-json
    /// </summary>
    public IDictionary<string, string>? VariablesJson { get; set; }

    /// <summary>
    /// Set the metadata field KEY to the value VAL. Values will be parsed as YAML boolean or string values.
    /// https://pandoc.org/MANUAL.html#option--metadata
    /// </summary>
    public IDictionary<string, string>? Metadata { get; set; }

    /// <summary>
    /// Read metadata from the supplied YAML (or JSON) file.
    /// https://pandoc.org/MANUAL.html#option--metadata-file
    /// </summary>
    public string? MetadataFile { get; set; }

    /// <summary>
    /// Produce a standalone HTML file with no external dependencies, using data: URIs to incorporate the contents of linked scripts, stylesheets, images, and videos. The resulting file should be self-contained.
    /// https://pandoc.org/MANUAL.html#option--embed-resources%5B
    /// </summary>
    public bool EmbedResources { get; set; }

    /// <summary>
    /// Use external links to images rather than embedding them.
    /// https://pandoc.org/MANUAL.html#option--link-images%5B
    /// </summary>
    public bool LinkImages { get; set; }

    /// <summary>
    /// Set the request header NAME to the value VALUE when making HTTP requests.
    /// https://pandoc.org/MANUAL.html#option--request-header
    /// </summary>
    public IDictionary<string, string>? RequestHeaders { get; set; }

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

        if (Variables != null)
        {
            foreach (var (key, value) in Variables)
            {
                yield return $"--variable={key}:{value}";
            }
        }

        if (VariablesJson != null)
        {
            foreach (var (key, value) in VariablesJson)
            {
                yield return $"--variable-json={key}:{value}";
            }
        }

        if (Metadata != null)
        {
            foreach (var (key, value) in Metadata)
            {
                yield return $"--metadata={key}:{value}";
            }
        }

        if (MetadataFile != null)
        {
            yield return $"--metadata-file={MetadataFile}";
        }

        if (EmbedResources)
        {
            yield return "--embed-resources";
        }

        if (LinkImages)
        {
            yield return "--link-images";
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
            yield return $"--wrap={Wrap.Value.ToString().ToLower()}";
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
        if (Citeproc)
        {
            yield return "--citeproc";
        }
        if (Bibliography != null)
        {
            yield return $"--bibliography={Bibliography}";
        }
        if (Csl != null)
        {
            yield return $"--csl={Csl}";
        }
        if (CitationAbbreviations != null)
        {
            yield return $"--citation-abbreviations={CitationAbbreviations}";
        }
        if (MathMl)
        {
            yield return "--mathml";
        }
        if (MathJax != null)
        {
            yield return $"--mathjax={MathJax}";
        }
        if (KaTeX != null)
        {
            yield return $"--katex={KaTeX}";
        }
        if (WebTeX != null)
        {
            yield return $"--webtex={WebTeX}";
        }
        if (GladTeX)
        {
            yield return "--gladtex";
        }
        if (RequestHeaders != null)
        {
            foreach (var (name, value) in RequestHeaders)
            {
                yield return $"--request-header={name}:{value}";
            }
        }

        if (ResourcePaths != null)
        {
            var split = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? ";" : ":";
            yield return $"--resource-path={string.Join(split, ResourcePaths)}";
        }
    }
}
