#### BibLaTeXIn

```cs
/// <summary>
/// https://ctan.org/pkg/biblatex
/// </summary>
public class BibLaTeXIn :
    InOptions
{
    protected override string Format => "biblatex";
}
```


#### BibTexIn

```cs
/// <summary>
/// https://ctan.org/pkg/bibtex
/// </summary>
public class BibTexIn :
    InOptions
{
    protected override string Format => "bibtex";
}
```


#### CreoleIn

```cs
/// <summary>
/// http://www.wikicreole.org/wiki/Creole1.0
/// </summary>
public class CreoleIn :
    InOptions
{
    protected override string Format => "creole";
}
```


#### CsvIn

```cs
/// <summary>
/// https://datatracker.ietf.org/doc/html/rfc4180
/// </summary>
public class CsvIn :
    InOptions
{
    protected override string Format => "csv";
}
```


#### DocBookIn

```cs
/// <summary>
/// https://docbook.org/
/// </summary>
public class DocBookIn :
    InOptions
{
    protected override string Format => "docbook";
}
```


#### DocxIn

```cs
/// <summary>
/// https://en.wikipedia.org/wiki/Office_Open_XML
/// </summary>
public class DocxIn :
    InOptions
{
    protected override string Format => "docx";

    /// <summary>
    /// Specifies what to do with insertions, deletions, and comments produced
    /// https://pandoc.org/MANUAL.html#option--track-changes
    /// </summary>
    public TrackChanges? TrackChanges { get; set; }

    public override IEnumerable<string> GetArguments()
    {
        foreach (var argument in base.GetArguments())
        {
            yield return argument;
        }

        if (TrackChanges != null)
        {
            yield return $"--track-changes={TrackChanges.Value.ToString().ToLower()}";
        }
    }
}
```


#### DokuWikiIn

```cs
/// <summary>
/// https://www.dokuwiki.org/dokuwiki
/// </summary>
public class DokuWikiIn :
    InOptions
{
    protected override string Format => "dokuwiki";
}
```


#### EmacsOrgIn

```cs
/// <summary>
/// https://orgmode.org/
/// </summary>
public class EmacsOrgIn :
    InOptions
{
    protected override string Format => "org";
}
```


#### EpubIn

```cs
/// <summary>
/// http://idpf.org/epub
/// </summary>
public class EpubIn :
    InOptions
{
    protected override string Format => "epub";
}
```


#### Fib2In

```cs
/// <summary>
/// http://www.fictionbook.org/index.php/Eng:XML_Schema_Fictionbook_2.1
/// </summary>
public class Fib2In :
    InOptions
{
    protected override string Format => "fb2";
}
```


#### GhMdIn

```cs
/// <summary>
/// https://help.github.com/articles/github-flavored-markdown/
/// </summary>
public class GhMdIn :
    InOptions
{
    protected override string Format => "gfm";
}
```


#### HaddockIn

```cs
/// <summary>
/// https://www.haskell.org/haddock/doc/html/ch03s08.html
/// </summary>
public class HaddockIn :
    InOptions
{
    protected override string Format => "haddock";
}
```


#### HaskellIn

```cs
public class HaskellIn :
    InOptions
{
    protected override string Format => "native";
}
```


#### HtmlIn

```cs
public class HtmlIn :
    InOptions
{
    protected override string Format => "html";
}
```


#### InOptions

```cs
public abstract class InOptions
{
    /// <summary>
    /// Shift heading levels by a positive or negative integer
    /// https://pandoc.org/MANUAL.html#option--shift-heading-level-by
    /// </summary>
    public int ShiftHeadingLevelBy { get; set; }
    /// <summary>
    /// Specify the number of spaces per tab (default is 4).
    /// https://pandoc.org/MANUAL.html#option--tab-stop
    /// </summary>
    public int? TabStop { get; set; }
    /// <summary>
    /// Specify classes to use for indented code blocks
    /// https://pandoc.org/MANUAL.html#option--indented-code-classes
    /// </summary>
    public IList<string>? IndentedCodeClasses { get; set; }
    /// <summary>
    /// Parse each file individually before combining for multifile documents
    /// https://pandoc.org/MANUAL.html#option--file-scope
    /// </summary>
    public bool FileScope { get; set; }
    /// <summary>
    /// Preserve tabs instead of converting them to spaces. (By default, pandoc converts tabs to spaces before parsing its input.)
    /// https://pandoc.org/MANUAL.html#option--preserve-tabs
    /// </summary>
    public bool PreserveTabs { get; set; }
    /// <summary>
    /// Specify an executable to be used as a filter transforming the pandoc AST after the input is parsed and before the output is written. The executable should read JSON from stdin and write JSON to stdout
    /// https://pandoc.org/MANUAL.html#option--filter
    /// </summary>
    public string? Filter { get; set; }
    /// <summary>
    /// Transform the document in a similar fashion as JSON filters (see --filter), but use pandoc’s built-in Lua filtering system.
    /// https://pandoc.org/MANUAL.html#option--lua-filter
    /// </summary>
    public string? LuaFilter { get; set; }
    //TODO:--metadata
    /// <summary>
    /// Set the metadata field KEY to the value VAL. A value specified on the command line overrides a value specified in the document using YAML metadata blocks. Values will be parsed as YAML boolean or string values. If no value is specified, the value will be treated as Boolean true.
    /// https://pandoc.org/MANUAL.html#option--metadata
    /// </summary>
    public string? Metadata { get; set; }
    /// <summary>
    /// Extract images and other media contained in or linked from the source document to the path DIR, creating it if necessary, and adjust the images references in the document so they point to the extracted files.
    /// https://pandoc.org/MANUAL.html#option--extract-media
    /// </summary>
    public string? ExtractMedia{ get; set; }
    /// <summary>
    /// Specifies a custom abbreviations file, with abbreviations one to a line.
    /// https://pandoc.org/MANUAL.html#option--abbreviations
    /// </summary>
    public string? Abbreviations{ get; set; }

    protected abstract string Format { get; }

    public virtual IEnumerable<string> GetArguments()
    {
        yield return $"--from={Format}";

        if (ShiftHeadingLevelBy != 0)
        {
            yield return $"--shift-heading-level-by={ShiftHeadingLevelBy}";
        }

        if (IndentedCodeClasses != null)
        {
            yield return $"--indented-code-classes={string.Join(",", IndentedCodeClasses)}";
        }

        if (FileScope)
        {
            yield return "file-scope";
        }

        if (Filter != null)
        {
            yield return $"--filter={Filter}";
        }

        if (LuaFilter != null)
        {
            yield return $"--lua-filter={LuaFilter}";
        }

        if (Metadata != null)
        {
            yield return $"--metadata-file={Metadata}";
        }

        if (PreserveTabs)
        {
            yield return "--preserve-tabs";
        }

        if (TabStop != null)
        {
            yield return $"--tab-stop={TabStop}";
        }

        if (ExtractMedia != null)
        {
            yield return $"--extract-media={ExtractMedia}";
        }

        if (Abbreviations != null)
        {
            yield return $"--abbreviations={Abbreviations}";
        }
    }
}
```


#### JatsIn

```cs
/// <summary>
/// https://jats.nlm.nih.gov/
/// </summary>
public class JatsIn :
    InOptions
{
    protected override string Format => "jats";
}
```


#### JiraIn

```cs
/// <summary>
/// https://jira.atlassian.com/secure/WikiRendererHelpAction.jspa?section=all
/// </summary>
public class JiraIn :
    InOptions
{
    protected override string Format => "jira";
}
```


#### JsonIn

```cs
public class JsonIn :
    InOptions
{
    protected override string Format => "json";
}
```


#### JupyterIn

```cs
/// <summary>
/// https://nbformat.readthedocs.io/en/latest/
/// </summary>
public class JupyterIn :
    InOptions
{
    protected override string Format => "ipynb";
}
```


#### LaTexIn

```cs
/// <summary>
/// https://www.latex-project.org/
/// </summary>
public class LaTexIn :
    InOptions
{
    /// <summary>
    /// Specify a default extension to use when image paths/URLs have no extension
    /// https://pandoc.org/MANUAL.html#option--default-image-extension
    /// </summary>
    public string? DefaultImageExtension { get; set; }

    public override IEnumerable<string> GetArguments()
    {
        foreach (var argument in base.GetArguments())
        {
            yield return argument;
        }

        if (DefaultImageExtension != null)
        {
            yield return $"--default-image-extension={DefaultImageExtension}";
        }
    }

    protected override string Format => "latex";
}
```


#### MediaWikiIn

```cs
/// <summary>
/// https://www.mediawiki.org/wiki/Help:Formatting
/// </summary>
public class MediaWikiIn :
    InOptions
{
    protected override string Format => "mediawiki";
}
```


#### MuseIn

```cs
/// <summary>
/// https://amusewiki.org/library/manual
/// </summary>
public class MuseIn :
    InOptions
{
    protected override string Format => "muse";
}
```


#### OdtIn

```cs
/// <summary>
/// https://en.wikipedia.org/wiki/OpenDocument
/// </summary>
public class OdtIn :
    InOptions
{
    protected override string Format => "odt";
}
```


#### OpmlIn

```cs
/// <summary>
/// http://opml.org/spec2.opml
/// </summary>
public class OpmlIn :
    InOptions
{
    protected override string Format => "opml";
}
```


#### RoffManIn

```cs
/// <summary>
/// https://man.cx/groff_man(7)
/// </summary>
public class RoffManIn :
    InOptions
{
    protected override string Format => "man";
}
```


#### RstIn

```cs
/// <summary>
/// https://docutils.sourceforge.io/docs/ref/rst/introduction.html
/// </summary>
public class RstIn :
    InOptions
{
    protected override string Format => "rst";
}
```


#### RtfIn

```cs
/// <summary>
/// https://en.wikipedia.org/wiki/Rich_Text_Format
/// </summary>
public class RtfIn :
    InOptions
{
    protected override string Format => "rtf";
}
```


#### T2tIn

```cs
/// <summary>
/// https://txt2tags.org/
/// </summary>
public class T2tIn :
    InOptions
{
    protected override string Format => "t2t";
}
```


#### TextileIn

```cs
/// <summary>
/// https://www.promptworks.com/textile
/// </summary>
public class TextileIn :
    InOptions
{
    protected override string Format => "textile";
}
```


#### TikiWikiIn

```cs
/// <summary>
/// https://twiki.org/cgi-bin/view/TWiki/TextFormattingRules
/// </summary>
public class TikiWikiIn :
    InOptions
{
    protected override string Format => "tikiwiki";
}
```


#### TrackChanges

```cs
public enum TrackChanges
{
    Accept,
    Reject,
    All
}
```


#### TWikiIn

```cs
/// <summary>
/// https://twiki.org/cgi-bin/view/TWiki/TextFormattingRules
/// </summary>
public class TWikiIn :
    InOptions
{
    protected override string Format => "twiki";
}
```


#### VimWikiIn

```cs
/// <summary>
/// https://vimwiki.github.io/
/// </summary>
public class VimWikiIn :
    InOptions
{
    protected override string Format => "vimwiki";
}
```


#### CommonMarkIn

```cs
/// <summary>
/// https://commonmark.org/
/// </summary>
public class CommonMarkIn :
    InOptions
{
    protected override string Format => "commonmark";

    /// <summary>
    /// Specify a default extension to use when image paths/URLs have no extension
    /// https://pandoc.org/MANUAL.html#option--default-image-extension
    /// </summary>
    public string? DefaultImageExtension { get; set; }

    public override IEnumerable<string> GetArguments()
    {
        foreach (var argument in base.GetArguments())
        {
            yield return argument;
        }

        if (DefaultImageExtension != null)
        {
            yield return $"--default-image-extension={DefaultImageExtension}";
        }
    }
}
```


#### CommonMarkXIn

```cs
/// <summary>
/// https://commonmark.org/
/// </summary>
public class CommonMarkXIn :
    InOptions
{
    protected override string Format => "commonmark_x";

    /// <summary>
    /// Specify a default extension to use when image paths/URLs have no extension
    /// https://pandoc.org/MANUAL.html#option--default-image-extension
    /// </summary>
    public string? DefaultImageExtension { get; set; }

    public override IEnumerable<string> GetArguments()
    {
        foreach (var argument in base.GetArguments())
        {
            yield return argument;
        }

        if (DefaultImageExtension != null)
        {
            yield return $"--default-image-extension={DefaultImageExtension}";
        }
    }
}
```


#### MdStrictIn

```cs
/// <summary>
/// https://daringfireball.net/projects/markdown/
/// </summary>
public class MdStrictIn :
    InOptions
{
    protected override string Format => "markdown_strict";

    /// <summary>
    /// Specify a default extension to use when image paths/URLs have no extension
    /// https://pandoc.org/MANUAL.html#option--default-image-extension
    /// </summary>
    public string? DefaultImageExtension { get; set; }

    public override IEnumerable<string> GetArguments()
    {
        foreach (var argument in base.GetArguments())
        {
            yield return argument;
        }

        if (DefaultImageExtension != null)
        {
            yield return $"--default-image-extension={DefaultImageExtension}";
        }
    }
}
```


#### MultiMdIn

```cs
/// <summary>
/// https://fletcherpenney.net/multimarkdown/
/// </summary>
public class MultiMdIn :
    InOptions
{
    protected override string Format => "markdown_mmd";

    /// <summary>
    /// Specify a default extension to use when image paths/URLs have no extension
    /// https://pandoc.org/MANUAL.html#option--default-image-extension
    /// </summary>
    public string? DefaultImageExtension { get; set; }

    public override IEnumerable<string> GetArguments()
    {
        foreach (var argument in base.GetArguments())
        {
            yield return argument;
        }

        if (DefaultImageExtension != null)
        {
            yield return $"--default-image-extension={DefaultImageExtension}";
        }
    }
}
```


#### PandocMdIn

```cs
/// <summary>
/// https://pandoc.org/MANUAL.html#pandocs-markdown
/// </summary>
public class PandocMdIn :
    InOptions
{
    protected override string Format => "markdown";

    /// <summary>
    /// Specify a default extension to use when image paths/URLs have no extension
    /// https://pandoc.org/MANUAL.html#option--default-image-extension
    /// </summary>
    public string? DefaultImageExtension { get; set; }

    public override IEnumerable<string> GetArguments()
    {
        foreach (var argument in base.GetArguments())
        {
            yield return argument;
        }

        if (DefaultImageExtension != null)
        {
            yield return $"--default-image-extension={DefaultImageExtension}";
        }
    }
}
```


#### PhpMdExtraIn

```cs
/// <summary>
/// https://michelf.ca/projects/php-markdown/extra/
/// </summary>
public class PhpMdExtraIn :
    InOptions
{
    protected override string Format => "markdown_phpextra";

    /// <summary>
    /// Specify a default extension to use when image paths/URLs have no extension
    /// https://pandoc.org/MANUAL.html#option--default-image-extension
    /// </summary>
    public string? DefaultImageExtension { get; set; }

    public override IEnumerable<string> GetArguments()
    {
        foreach (var argument in base.GetArguments())
        {
            yield return argument;
        }

        if (DefaultImageExtension != null)
        {
            yield return $"--default-image-extension={DefaultImageExtension}";
        }
    }
}
```


