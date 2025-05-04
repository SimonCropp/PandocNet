# <img src="/src/icon.png" height="30px"> PandocNet

[![Build status](https://ci.appveyor.com/api/projects/status/naxouwk164twkgn3?svg=true)](https://ci.appveyor.com/project/SimonCropp/PandocNet)
[![NuGet Status](https://img.shields.io/nuget/v/Pandoc.svg)](https://www.nuget.org/packages/Pandoc/)

Conversion of documents via [Pandoc](https://pandoc.org/). Wraps pandoc.exe using [CliWrap](https://github.com/Tyrrrz/CliWrap) and provides strong typed options for document formats.

**See [Milestones](../../milestones?state=closed) for release notes.**


## NuGet package

https://nuget.org/packages/Pandoc/


## Usage


### Pandoc Path

By default `pandoc.exe` is expected to be accessible in the current environmenst `Path`.

[Installing Pandoc](https://pandoc.org/installing.html).

This can be changed:

<!-- snippet: PandocPath -->
<a id='snippet-PandocPath'></a>
```cs
var engine = new PandocEngine(@"D:\Tools\pandoc.exe");
```
<sup><a href='/src/Tests/Samples.cs#L9-L13' title='Snippet source file'>snippet source</a> | <a href='#snippet-PandocPath' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->


### Text

<!-- snippet: text -->
<a id='snippet-text'></a>
```cs
var html = await PandocInstance.ConvertToText<CommonMarkIn, HtmlOut>("*text*");
```
<sup><a href='/src/Tests/Samples.cs#L47-L51' title='Snippet source file'>snippet source</a> | <a href='#snippet-text' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->


### Streams

<!-- snippet: streams -->
<a id='snippet-streams'></a>
```cs
await using var inStream = File.OpenRead("sample.md");
await using var outStream = File.OpenWrite("output.html");
await PandocInstance.Convert<CommonMarkIn, HtmlOut>(inStream, outStream);
```
<sup><a href='/src/Tests/Samples.cs#L32-L38' title='Snippet source file'>snippet source</a> | <a href='#snippet-streams' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->


### Files

<!-- snippet: files -->
<a id='snippet-files'></a>
```cs
await PandocInstance.Convert<CommonMarkIn, HtmlOut>("sample.md", "output.html");
```
<sup><a href='/src/Tests/Samples.cs#L19-L23' title='Snippet source file'>snippet source</a> | <a href='#snippet-files' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->


### Custom Options

<!-- snippet: custom-options -->
<a id='snippet-custom-options'></a>
```cs
var html = await PandocInstance.ConvertToText(
    """

    # Heading1

    text

    ## Heading2

    text

    """,
    new CommonMarkIn
    {
        ShiftHeadingLevelBy = 2
    },
    new HtmlOut
    {
        NumberOffsets = new List<int> {3}
    });
```
<sup><a href='/src/Tests/Samples.cs#L59-L82' title='Snippet source file'>snippet source</a> | <a href='#snippet-custom-options' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->


### Inputs

#### BibLaTeXIn<!-- include: input. path: /src/input.include.md -->

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

<!-- endInclude -->


### Outputs

#### AsciiDocOut<!-- include: output. path: /src/output.include.md -->

```cs
/// <summary>
/// https://en.wikipedia.org/wiki/AsciiDoc
/// </summary>
public class AsciiDocOut :
    OutOptions
{
    public override string Format => "asciidoc";
}
```


#### AsciiDoctorOut

```cs
/// <summary>
/// https://asciidoctor.org/
/// </summary>
public class AsciiDoctorOut :
    OutOptions
{
    public override string Format => "asciidoctor";
}
```


#### BibLaTeXOut

```cs
/// <summary>
/// https://ctan.org/pkg/biblatex
/// </summary>
public class BibLaTeXOut :
    OutOptions
{
    public override string Format => "biblatex";
}
```


#### BibTeXOut

```cs
/// <summary>
/// https://ctan.org/pkg/bibtex
/// </summary>
public class BibTeXOut :
    OutOptions
{
    public override string Format => "bibtex";
}
```


#### ConTeXtOut

```cs
/// <summary>
/// https://www.contextgarden.net/
/// </summary>
public class ConTeXtOut :
    OutOptions
{
    public override string Format => "context";

    /// <summary>
    /// Number section headings
    /// https://pandoc.org/MANUAL.html#option--number-sections
    /// </summary>
    public bool NumberSections { get; set; }
    /// <summary>
    /// Treat top-level headings as the given division output.The hierarchy order is part, chapter, then section; all headings are shifted such that the top-level heading becomes the specified type
    /// https://pandoc.org/MANUAL.html#option--top-level-division
    /// </summary>
    public TopLevelDivision? TopLevelDivision { get; set; }

    public override IEnumerable<string> GetArguments()
    {
        foreach (var argument in base.GetArguments())
        {
            yield return argument;
        }

        if (NumberSections)
        {
            yield return "--number-sections";
        }

        if (TopLevelDivision != null)
        {
            yield return $"--top-level-division={TopLevelDivision}";
        }
    }
}
```


#### CslJsonOut

```cs
/// <summary>
/// https://citeproc-js.readthedocs.io/en/latest/csl-json/markup.html
/// </summary>
public class CslJsonOut :
    OutOptions
{
    public override string Format => "csljson";
}
```


#### DocBook4Out

```cs
/// <summary>
/// https://docbook.org/
/// </summary>
public class DocBook4Out :
    OutOptions
{
    public override string Format => "docbook4";

    /// <summary>
    /// Treat top-level headings as the given division output.The hierarchy order is part, chapter, then section; all headings are shifted such that the top-level heading becomes the specified type
    /// https://pandoc.org/MANUAL.html#option--top-level-division
    /// </summary>
    public TopLevelDivision? TopLevelDivision { get; set; }
    /// <summary>
    /// Specify STRING as a prefix at the beginning of the title that appears in the HTML header (but not in the title as it appears at the beginning of the HTML body).
    /// https://pandoc.org/MANUAL.html#option--id-prefix
    /// </summary>
    public string? IdPrefix { get; set; }

    public override IEnumerable<string> GetArguments()
    {
        foreach (var argument in base.GetArguments())
        {
            yield return argument;
        }

        if (IdPrefix != null)
        {
            yield return $"--id-prefix={IdPrefix}";
        }

        if (TopLevelDivision != null)
        {
            yield return $"--top-level-division={TopLevelDivision}";
        }
    }
}
```


#### DocBook5Out

```cs
/// <summary>
/// https://docbook.org/
/// </summary>
public class DocBook5Out :
    OutOptions
{
    public override string Format => "docbook5";

    /// <summary>
    /// Treat top-level headings as the given division output.The hierarchy order is part, chapter, then section; all headings are shifted such that the top-level heading becomes the specified type
    /// https://pandoc.org/MANUAL.html#option--top-level-division
    /// </summary>
    public TopLevelDivision? TopLevelDivision { get; set; }
    /// <summary>
    /// Specify STRING as a prefix at the beginning of the title that appears in the HTML header (but not in the title as it appears at the beginning of the HTML body).
    /// https://pandoc.org/MANUAL.html#option--id-prefix
    /// </summary>
    public string? IdPrefix { get; set; }

    public override IEnumerable<string> GetArguments()
    {
        foreach (var argument in base.GetArguments())
        {
            yield return argument;
        }

        if (TopLevelDivision != null)
        {
            yield return $"--top-level-division={TopLevelDivision}";
        }
        if (IdPrefix != null)
        {
            yield return $"--id-prefix={IdPrefix}";
        }
    }
}
```


#### DocxOut

```cs
/// <summary>
/// https://en.wikipedia.org/wiki/Office_Open_XML
/// </summary>
public class DocxOut :
    OutOptions
{
    public override string Format => "docx";

    /// <summary>
    /// Number section headings
    /// https://pandoc.org/MANUAL.html#option--number-sections
    /// </summary>
    public bool NumberSections { get; set; }

    /// <summary>
    /// Use the specified file as a style reference in producing
    /// https://pandoc.org/MANUAL.html#option--reference-doc
    /// </summary>
    public string? ReferenceDoc { get; set; }

    public override IEnumerable<string> GetArguments()
    {
        foreach (var argument in base.GetArguments())
        {
            yield return argument;
        }

        if (NumberSections)
        {
            yield return "--number-sections";
        }

        if (ReferenceDoc != null)
        {
            yield return $"--reference-doc={ReferenceDoc}";
        }
    }
}
```


#### DokuWikiOut

```cs
/// <summary>
/// https://www.dokuwiki.org/dokuwiki
/// </summary>
public class DokuWikiOut :
    OutOptions
{
    public override string Format => "dokuwiki";
}
```


#### EmacsOrgOut

```cs
/// <summary>
/// https://orgmode.org/
/// </summary>
public class EmacsOrgOut :
    OutOptions
{
    public override string Format => "org";
}
```


#### Eol

```cs
public enum Eol
{
    Crlf,
    Lf,
    Native
}
```


#### Epub2Out

```cs
/// <summary>
/// https://pandoc.org/MANUAL.html
/// </summary>
public class Epub2Out :
    OutOptions
{
    public override string Format => "epub2";

    /// <summary>
    /// Specify whether footnotes (and references, if reference-links is set) are placed at the end of the current (top-level) block, the current section, or the document.
    /// https://pandoc.org/MANUAL.html#option--reference-location
    /// </summary>
    public ReferenceLocation? ReferenceLocation { get; set; }
    /// <summary>
    /// Number section headings
    /// https://pandoc.org/MANUAL.html#option--number-sections
    /// </summary>
    public bool NumberSections { get; set; }
    /// <summary>
    /// Link to a CSS style sheet. This option can be used repeatedly to include multiple files. They will be included in the order specified.
    /// https://pandoc.org/MANUAL.html#option--css
    /// </summary>
    public string? Css { get; set; }
    /// <summary>
    /// Use the specified image as the EPUB cover
    /// https://pandoc.org/MANUAL.html#option--epub-cover-image
    /// </summary>
    public string? CoverImage { get; set; }
    /// <summary>
    /// Look in the specified XML file for metadata for the EPUB.
    /// https://pandoc.org/MANUAL.html#option--epub-metadata
    /// </summary>
    public string? Metadata { get; set; }
    /// <summary>
    /// Specify the subdirectory in the OCF container that is to hold the EPUB-specific contents
    /// https://pandoc.org/MANUAL.html#option--epub-subdirectory
    /// </summary>
    public string? SubDirectory { get; set; }
    /// <summary>
    /// Embed the specified font in the EPUB. This option can be repeated to embed multiple fonts
    /// https://pandoc.org/MANUAL.html#option--epub-embed-font
    /// </summary>
    public string? EmbedFont { get; set; }
    /// <summary>
    /// Specify the heading level at which to split the EPUB into separate “chapter” files
    /// https://pandoc.org/MANUAL.html#option--epub-chapter-level
    /// </summary>
    public int? ChapterLevel { get; set; }

    public override IEnumerable<string> GetArguments()
    {
        foreach (var argument in base.GetArguments())
        {
            yield return argument;
        }

        if (ReferenceLocation != null)
        {
            yield return $"--reference-location={ReferenceLocation}";
        }

        if (NumberSections)
        {
            yield return "--number-sections";
        }
        if (Css != null)
        {
            yield return $"--css={Css}";
        }
        if (CoverImage != null)
        {
            yield return $"--epub-cover-image={CoverImage}";
        }
        if (Metadata != null)
        {
            yield return $"--epub-metadata={Metadata}";
        }
        if (EmbedFont != null)
        {
            yield return $"--epub-embed-font={EmbedFont}";
        }
        if (ChapterLevel != null)
        {
            yield return $"--epub-chapter-level={ChapterLevel}";
        }
        if (SubDirectory != null)
        {
            yield return $"--epub-subdirectory={SubDirectory}";
        }
    }
}
```


#### Epub3Out

```cs
/// <summary>
/// https://pandoc.org/MANUAL.html
/// </summary>
public class Epub3Out :
    OutOptions
{
    public override string Format => "epub3";

    /// <summary>
    /// Specify whether footnotes (and references, if reference-links is set) are placed at the end of the current (top-level) block, the current section, or the document.
    /// https://pandoc.org/MANUAL.html#option--reference-location
    /// </summary>
    public ReferenceLocation? ReferenceLocation { get; set; }
    /// <summary>
    /// Number section headings
    /// https://pandoc.org/MANUAL.html#option--number-sections
    /// </summary>
    public bool NumberSections { get; set; }
    /// <summary>
    /// Link to a CSS style sheet. This option can be used repeatedly to include multiple files. They will be included in the order specified.
    /// https://pandoc.org/MANUAL.html#option--css
    /// </summary>
    public string? Css { get; set; }
    /// <summary>
    /// Use the specified image as the EPUB cover
    /// https://pandoc.org/MANUAL.html#option--epub-cover-image
    /// </summary>
    public string? CoverImage { get; set; }
    /// <summary>
    /// Look in the specified XML file for metadata for the EPUB.
    /// https://pandoc.org/MANUAL.html#option--epub-metadata
    /// </summary>
    public string? Metadata { get; set; }
    /// <summary>
    /// Specify the subdirectory in the OCF container that is to hold the EPUB-specific contents
    /// https://pandoc.org/MANUAL.html#option--epub-subdirectory
    /// </summary>
    public string? SubDirectory { get; set; }
    /// <summary>
    /// Embed the specified font in the EPUB. This option can be repeated to embed multiple fonts
    /// https://pandoc.org/MANUAL.html#option--epub-embed-font
    /// </summary>
    public string? EmbedFont { get; set; }
    /// <summary>
    /// Specify the heading level at which to split the EPUB into separate “chapter” files
    /// https://pandoc.org/MANUAL.html#option--epub-chapter-level
    /// </summary>
    public int? ChapterLevel { get; set; }

    public override IEnumerable<string> GetArguments()
    {
        foreach (var argument in base.GetArguments())
        {
            yield return argument;
        }

        if (ReferenceLocation != null)
        {
            yield return $"--reference-location={ReferenceLocation}";
        }

        if (NumberSections)
        {
            yield return "--number-sections";
        }
        if (Css != null)
        {
            yield return $"--css={Css}";
        }
        if (CoverImage != null)
        {
            yield return $"--epub-cover-image={CoverImage}";
        }
        if (Metadata != null)
        {
            yield return $"--epub-metadata={Metadata}";
        }
        if (EmbedFont != null)
        {
            yield return $"--epub-embed-font={EmbedFont}";
        }
        if (ChapterLevel != null)
        {
            yield return $"--epub-chapter-level={ChapterLevel}";
        }
        if (SubDirectory != null)
        {
            yield return $"--epub-subdirectory={SubDirectory}";
        }
    }
}
```


#### Fb2Out

```cs
/// <summary>
/// http://www.fictionbook.org/index.php/Eng:XML_Schema_Fictionbook_2.1
/// </summary>
public class Fb2Out :
    OutOptions
{
    public override string Format => "fb2";
}
```


#### HaddockOut

```cs
/// <summary>
/// https://www.haskell.org/haddock/doc/html/ch03s08.html
/// </summary>
public class HaddockOut :
    OutOptions
{
    public override string Format => "haddock";
}
```


#### HaskellOut

```cs
public class HaskellOut :
    OutOptions
{
    public override string Format => "native";
}
```


#### HtmlOut

```cs
public class HtmlOut :
    OutOptions
{
    public override string Format => "html";

    /// <summary>
    /// Produce a standalone HTML file with no external dependencies, using data: URIs to incorporate the contents of linked scripts, stylesheets, images, and videos
    /// https://pandoc.org/MANUAL.html#option--self-contained
    /// </summary>
    public bool SelfContained { get; set; }

    /// <summary>
    /// Use &lt;q&gt; tags for quotes in HTML. (This option only has an effect if the smart extension is enabled for the input format used.)
    /// https://pandoc.org/MANUAL.html#option--html-q-tags
    /// </summary>
    public bool HtmlQTags { get; set; }

    /// <summary>
    /// Wrap sections in &lt;section&gt; tags (or &lt;div&gt; tags for html4), and attach identifiers to the enclosing &lt;section> (or &lt;div&gt;) rather than the heading itself
    /// https://pandoc.org/MANUAL.html#option--section-divs
    /// </summary>
    public bool SectionDivs { get; set; }

    /// <summary>
    /// Use only ASCII characters in output
    /// https://pandoc.org/MANUAL.html#option--ascii
    /// </summary>
    public bool Ascii { get; set; }

    /// <summary>
    /// Specify whether footnotes (and references, if reference-links is set) are placed at the end of the current (top-level) block, the current section, or the document.
    /// https://pandoc.org/MANUAL.html#option--reference-location
    /// </summary>
    public ReferenceLocation? ReferenceLocation { get; set; }

    /// <summary>
    /// Number section headings
    /// https://pandoc.org/MANUAL.html#option--number-sections
    /// </summary>
    public bool NumberSections { get; set; }

    /// <summary>
    /// Number section headings
    /// https://pandoc.org/MANUAL.html#option--number-sections
    /// </summary>
    public IList<int>? NumberOffsets { get; set; }

    /// <summary>
    /// Specify STRING as a prefix at the beginning of the title that appears in the HTML header (but not in the title as it appears at the beginning of the HTML body).
    /// https://pandoc.org/MANUAL.html#option--id-prefix
    /// </summary>
    public string? IdPrefix { get; set; }

    /// <summary>
    /// Link to a CSS style sheet. This option can be used repeatedly to include multiple files. They will be included in the order specified.
    /// https://pandoc.org/MANUAL.html#option--css
    /// </summary>
    public string? Css { get; set; }

    /// <summary>
    /// Specify STRING as a prefix at the beginning of the title that appears in the HTML header (but not in the title as it appears at the beginning of the HTML body).
    /// https://pandoc.org/MANUAL.html#option--title-prefix
    /// </summary>
    public string? TitlePrefix { get; set; }

    public override IEnumerable<string> GetArguments()
    {
        foreach (var argument in base.GetArguments())
        {
            yield return argument;
        }

        if (SelfContained)
        {
            yield return "--self-contained";
        }

        if (Ascii)
        {
            yield return "--ascii";
        }

        if (HtmlQTags)
        {
            yield return "--html-q-tags";
        }

        if (ReferenceLocation != null)
        {
            yield return $"--reference-location={ReferenceLocation}";
        }

        if (NumberSections)
        {
            yield return "--number-sections";
        }

        if (NumberOffsets != null)
        {
            yield return $"--number-offset={string.Join(",", NumberOffsets)}";
        }

        if (SectionDivs)
        {
            yield return "--section-divs";
        }

        if (IdPrefix != null)
        {
            yield return $"--id-prefix={IdPrefix}";
        }

        if (Css != null)
        {
            yield return $"--css={Css}";
        }

        if (TitlePrefix != null)
        {
            yield return $"--title-prefix={TitlePrefix}";
        }
    }
}
```


#### IcmlOut

```cs
/// <summary>
/// https://wwwimages.adobe.com/www.adobe.com/content/dam/acom/en/devnet/indesign/sdk/cs6/idml/idml-cookbook.pdf
/// </summary>
public class IcmlOut :
    OutOptions
{
    public override string Format => "icml";
}
```


#### JatsArchivingOut

```cs
/// <summary>
/// https://jats.nlm.nih.gov/
/// </summary>
public class JatsArchivingOut :
    OutOptions
{
    public override string Format => "jats_archiving";

    /// <summary>
    /// Use only ASCII characters in output
    /// https://pandoc.org/MANUAL.html#option--ascii
    /// </summary>
    public bool Ascii { get; set; }

    public override IEnumerable<string> GetArguments()
    {
        foreach (var argument in base.GetArguments())
        {
            yield return argument;
        }

        if (Ascii)
        {
            yield return "--ascii";
        }
    }
}
```


#### JatsArticleAuthoringOut

```cs
/// <summary>
/// https://jats.nlm.nih.gov/
/// </summary>
public class JatsArticleAuthoringOut :
    OutOptions
{
    public override string Format => "jats_articleauthoring";

    /// <summary>
    /// Use only ASCII characters in output
    /// https://pandoc.org/MANUAL.html#option--ascii
    /// </summary>
    public bool Ascii { get; set; }

    public override IEnumerable<string> GetArguments()
    {
        foreach (var argument in base.GetArguments())
        {
            yield return argument;
        }

        if (Ascii)
        {
            yield return "--ascii";
        }
    }
}
```


#### JatsPublishingOut

```cs
/// <summary>
/// https://jats.nlm.nih.gov/
/// </summary>
public class JatsPublishingOut :
    OutOptions
{
    public override string Format => "jats_publishing";

    /// <summary>
    /// Use only ASCII characters in output
    /// https://pandoc.org/MANUAL.html#option--ascii
    /// </summary>
    public bool Ascii { get; set; }

    public override IEnumerable<string> GetArguments()
    {
        foreach (var argument in base.GetArguments())
        {
            yield return argument;
        }

        if (Ascii)
        {
            yield return "--ascii";
        }
    }
}
```


#### JiraOut

```cs
/// <summary>
/// https://jira.atlassian.com/secure/WikiRendererHelpAction.jspa?section=all
/// </summary>
public class JiraOut :
    OutOptions
{
    public override string Format => "jira";
}
```


#### JsonOut

```cs
public class JsonOut :
    OutOptions
{
    public override string Format => "json";
}
```


#### JupyterCellOut

```cs
public enum JupyterCellOutput
{
    All,
    None,
    Best
}
```


#### JupyterOut

```cs
/// <summary>
/// https://nbformat.readthedocs.io/en/latest/
/// </summary>
public class JupyterOut :
    OutOptions
{
    public override string Format => "ipynb";

    /// <summary>
    /// Determines how ipynb output cells are treated. all means that all of the data formats included in the original are preserved
    /// https://pandoc.org/MANUAL.html#option--ipynb-output
    /// </summary>
    public JupyterCellOutput? CellOutput { get; set; }

    public override IEnumerable<string> GetArguments()
    {
        foreach (var argument in base.GetArguments())
        {
            yield return argument;
        }

        if (CellOutput != null)
        {
            yield return $"--ipynb-output={CellOutput}";
        }
    }
}
```


#### LaTeXOut

```cs
/// <summary>
/// https://pandoc.org/MANUAL.html
/// </summary>
public class LaTeXOut :
    OutOptions
{
    public override string Format => "latex";

    /// <summary>
    /// Use only ASCII characters in output
    /// https://pandoc.org/MANUAL.html#option--ascii
    /// </summary>
    public bool Ascii { get; set; }

    /// <summary>
    /// Treat top-level headings as the given division output.The hierarchy order is part, chapter, then section; all headings are shifted such that the top-level heading becomes the specified type
    /// https://pandoc.org/MANUAL.html#option--top-level-division
    /// </summary>
    public TopLevelDivision? TopLevelDivision { get; set; }

    /// <summary>
    /// Number section headings
    /// https://pandoc.org/MANUAL.html#option--number-sections
    /// </summary>
    public bool NumberSections { get; set; }

    /// <summary>
    /// Number section headings
    /// https://pandoc.org/MANUAL.html#option--number-sections
    /// </summary>
    public bool Listings { get; set; }

    public override IEnumerable<string> GetArguments()
    {
        foreach (var argument in base.GetArguments())
        {
            yield return argument;
        }

        if (Ascii)
        {
            yield return "--ascii";
        }

        if (TopLevelDivision != null)
        {
            yield return $"--top-level-division={TopLevelDivision}";
        }

        if (NumberSections)
        {
            yield return "--number-sections";
        }

        if (Listings)
        {
            yield return "--listings";
        }
    }
}
```


#### MediaWikiOut

```cs
/// <summary>
/// https://www.mediawiki.org/wiki/Help:Formatting
/// </summary>
public class MediaWikiOut :
    OutOptions
{
    public override string Format => "mediawiki";
}
```


#### MuseOut

```cs
/// <summary>
/// https://amusewiki.org/library/manual
/// </summary>
public class MuseOut :
    OutOptions
{
    public override string Format => "muse";

    /// <summary>
    /// Specify whether footnotes (and references, if reference-links is set) are placed at the end of the current (top-level) block, the current section, or the document.
    /// https://pandoc.org/MANUAL.html#option--reference-location
    /// </summary>
    public ReferenceLocation? ReferenceLocation { get; set; }

    public override IEnumerable<string> GetArguments()
    {
        foreach (var argument in base.GetArguments())
        {
            yield return argument;
        }

        if (ReferenceLocation != null)
        {
            yield return $"--reference-location={ReferenceLocation}";
        }
    }
}
```


#### OdtOut

```cs
/// <summary>
/// https://en.wikipedia.org/wiki/OpenDocument
/// </summary>
public class OdtOut :
    OutOptions
{
    public override string Format => "odt";

    /// <summary>
    /// Use the specified file as a style reference in producing
    /// https://pandoc.org/MANUAL.html#option--reference-doc
    /// </summary>
    public string? ReferenceDoc { get; set; }

    public override IEnumerable<string> GetArguments()
    {
        foreach (var argument in base.GetArguments())
        {
            yield return argument;
        }

        if (ReferenceDoc != null)
        {
            yield return $"--reference-doc={ReferenceDoc}";
        }
    }
}
```


#### OpenDocumentOut

```cs
/// <summary>
/// http://opendocument.xml.org/
/// </summary>
public class OpenDocumentOut :
    OutOptions
{
    public override string Format => "opendocument";
}
```


#### OpmlOut

```cs
/// <summary>
/// http://dev.opml.org/spec2.html
/// </summary>
public class OpmlOut :
    OutOptions
{
    public override string Format => "opml";
}
```


#### OutOptions

```cs
using System.Runtime.InteropServices;



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
        //TODO: request-header

        if (ResourcePaths != null)
        {
            var split = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? ";" : ":";
            yield return $"--resource-path={string.Join(split, ResourcePaths)}";
        }
    }
}
```


#### ReferenceLocation

```cs
public enum ReferenceLocation
{
    Block,
    Section,
    Document
}
```


#### RoffManOut

```cs
/// <summary>
/// https://man.cx/groff_man(7)
/// </summary>
public class RoffManOut :
    OutOptions
{
    public override string Format => "man";
}
```


#### RoffMsOut

```cs
/// <summary>
/// https://man.cx/groff_ms(7)
/// </summary>
public class RoffMsOut :
    OutOptions
{
    public override string Format => "ms";

    /// <summary>
    /// Use only ASCII characters in output
    /// https://pandoc.org/MANUAL.html#option--ascii
    /// </summary>
    public bool Ascii { get; set; }

    /// <summary>
    /// Number section headings
    /// https://pandoc.org/MANUAL.html#option--number-sections
    /// </summary>
    public bool NumberSections { get; set; }

    public override IEnumerable<string> GetArguments()
    {
        foreach (var argument in base.GetArguments())
        {
            yield return argument;
        }

        if (Ascii)
        {
            yield return "--ascii";
        }

        if (NumberSections)
        {
            yield return "--number-sections";
        }
    }
}
```


#### RstOut

```cs
/// <summary>
/// https://docutils.sourceforge.io/docs/ref/rst/introduction.html
/// </summary>
public class RstOut :
    OutOptions
{
    public override string Format => "rst";
    /// <summary>
    /// Use reference-style links, rather than inline links
    /// https://pandoc.org/MANUAL.html#option--reference-links
    /// </summary>
    public bool ReferenceLinks { get; set; }

    public override IEnumerable<string> GetArguments()
    {
        foreach (var argument in base.GetArguments())
        {
            yield return argument;
        }

        if (ReferenceLinks)
        {
            yield return "--reference-links";
        }
    }
}
```


#### RtfOut

```cs
/// <summary>
/// https://en.wikipedia.org/wiki/Rich_Text_Format
/// </summary>
public class RtfOut :
    OutOptions
{
    public override string Format => "rtf";
}
```


#### TeiOut

```cs
/// <summary>
/// https://github.com/TEIC/TEI-Simple
/// </summary>
public class TeiOut :
    OutOptions
{
    public override string Format => "tei";

    /// <summary>
    /// Treat top-level headings as the given division output.The hierarchy order is part, chapter, then section; all headings are shifted such that the top-level heading becomes the specified type
    /// https://pandoc.org/MANUAL.html#option--top-level-division
    /// </summary>
    public TopLevelDivision? TopLevelDivision { get; set; }
    /// <summary>
    /// Number section headings
    /// https://pandoc.org/MANUAL.html#option--number-sections
    /// </summary>
    public bool NumberSections { get; set; }

    public override IEnumerable<string> GetArguments()
    {
        foreach (var argument in base.GetArguments())
        {
            yield return argument;
        }

        if (TopLevelDivision != null)
        {
            yield return $"--top-level-division={TopLevelDivision}";
        }
        if (NumberSections)
        {
            yield return "--number-sections";
        }
    }
}
```


#### TexInfoOut

```cs
/// <summary>
/// https://www.gnu.org/software/texinfo/
/// </summary>
public class TexInfoOut :
    OutOptions
{
    public override string Format => "texinfo";
}
```


#### TextileOut

```cs
/// <summary>
/// https://www.promptworks.com/textile
/// </summary>
public class TextileOut :
    OutOptions
{
    public override string Format => "textile";
}
```


#### TopLevelDivision

```cs
/// <summary>
/// Treat top-level headings as the given division type in LaTeX, ConTeXt, DocBook, and TEI output
/// https://pandoc.org/MANUAL.html#option--top-level-division
/// </summary>
public enum TopLevelDivision
{
    Default,
    Section,
    Chapter,
    Part
}
```


#### TxtOut

```cs
public class TxtOut :
    OutOptions
{
    public override string Format => "plain";
}
```


#### Wrap

```cs
/// <summary>
/// Determine how text is wrapped in the output (the source code, not the rendered version).
/// https://pandoc.org/MANUAL.html#option--wrap
/// </summary>
public enum Wrap
{
    Auto,
    None,
    Preserve
}
```


#### XWikiOut

```cs
/// <summary>
/// https://www.xwiki.org/xwiki/bin/view/Documentation/UserGuide/Features/XWikiSyntax/
/// </summary>
public class XWikiOut :
    OutOptions
{
    public override string Format => "xwiki";
}
```


#### ZimWikiOut

```cs
/// <summary>
/// https://zim-wiki.org/manual/Help/Wiki_Syntax.html
/// </summary>
public class ZimWikiOut :
    OutOptions
{
    public override string Format => "zimwiki";
}
```


#### CommonMarkOut

```cs
/// <summary>
/// https://commonmark.org/
/// </summary>
public class CommonMarkOut :
    OutOptions
{
    public override string Format => "commonmark";

    /// <summary>
    /// Use only ASCII characters in output
    /// https://pandoc.org/MANUAL.html#option--ascii
    /// </summary>
    public bool Ascii { get; set; }
    /// <summary>
    /// Use reference-style links, rather than inline links
    /// https://pandoc.org/MANUAL.html#option--reference-links
    /// </summary>
    public bool ReferenceLinks { get; set; }
    /// <summary>
    /// Specify whether footnotes (and references, if reference-links is set) are placed at the end of the current (top-level) block, the current section, or the document.
    /// https://pandoc.org/MANUAL.html#option--reference-location
    /// </summary>
    public ReferenceLocation? ReferenceLocation { get; set; }
    /// <summary>
    /// Specify whether to use ATX-style (#-prefixed) or Setext-style (underlined) headings for level 1 and 2 headings in Markdown output
    /// https://pandoc.org/MANUAL.html#option--markdown-headings
    /// </summary>
    public MarkdownHeadings? MarkdownHeadings { get; set; }

    public override IEnumerable<string> GetArguments()
    {
        foreach (var argument in base.GetArguments())
        {
            yield return argument;
        }

        if (Ascii)
        {
            yield return "--ascii";
        }
        if (ReferenceLinks)
        {
            yield return "--reference-links";
        }
        if (ReferenceLocation != null)
        {
            yield return $"--reference-location={ReferenceLocation}";
        }
        if (MarkdownHeadings != null)
        {
            yield return $"--markdown-headings={MarkdownHeadings}";
        }
    }
}
```


#### CommonMarkXOut

```cs
/// <summary>
/// https://commonmark.org/
/// </summary>
public class CommonMarkXOut :
    OutOptions
{
    public override string Format => "commonmark_x";

    /// <summary>
    /// Use only ASCII characters in output
    /// https://pandoc.org/MANUAL.html#option--ascii
    /// </summary>
    public bool Ascii { get; set; }
    /// <summary>
    /// Use reference-style links, rather than inline links
    /// https://pandoc.org/MANUAL.html#option--reference-links
    /// </summary>
    public bool ReferenceLinks { get; set; }
    /// <summary>
    /// Specify whether footnotes (and references, if reference-links is set) are placed at the end of the current (top-level) block, the current section, or the document.
    /// https://pandoc.org/MANUAL.html#option--reference-location
    /// </summary>
    public ReferenceLocation? ReferenceLocation { get; set; }
    /// <summary>
    /// Specify whether to use ATX-style (#-prefixed) or Setext-style (underlined) headings for level 1 and 2 headings in Markdown output
    /// https://pandoc.org/MANUAL.html#option--markdown-headings
    /// </summary>
    public MarkdownHeadings? MarkdownHeadings { get; set; }

    public override IEnumerable<string> GetArguments()
    {
        foreach (var argument in base.GetArguments())
        {
            yield return argument;
        }

        if (Ascii)
        {
            yield return "--ascii";
        }
        if (ReferenceLinks)
        {
            yield return "--reference-links";
        }
        if (ReferenceLocation != null)
        {
            yield return $"--reference-location={ReferenceLocation}";
        }
        if (MarkdownHeadings != null)
        {
            yield return $"--markdown-headings={MarkdownHeadings}";
        }
    }
}
```


#### GhMdOut

```cs
/// <summary>
/// https://help.github.com/articles/github-flavored-markdown/
/// </summary>
public class GhMdOut :
    OutOptions
{
    public override string Format => "gfm";

    /// <summary>
    /// Use only ASCII characters in output
    /// https://pandoc.org/MANUAL.html#option--ascii
    /// </summary>
    public bool Ascii { get; set; }
    /// <summary>
    /// Use reference-style links, rather than inline links
    /// https://pandoc.org/MANUAL.html#option--reference-links
    /// </summary>
    public bool ReferenceLinks { get; set; }
    /// <summary>
    /// Specify whether footnotes (and references, if reference-links is set) are placed at the end of the current (top-level) block, the current section, or the document.
    /// https://pandoc.org/MANUAL.html#option--reference-location
    /// </summary>
    public ReferenceLocation? ReferenceLocation { get; set; }
    /// <summary>
    /// Specify whether to use ATX-style (#-prefixed) or Setext-style (underlined) headings for level 1 and 2 headings in Markdown output
    /// https://pandoc.org/MANUAL.html#option--markdown-headings
    /// </summary>
    public MarkdownHeadings? MarkdownHeadings { get; set; }

    public override IEnumerable<string> GetArguments()
    {
        foreach (var argument in base.GetArguments())
        {
            yield return argument;
        }

        if (Ascii)
        {
            yield return "--ascii";
        }
        if (ReferenceLinks)
        {
            yield return "--reference-links";
        }
        if (ReferenceLocation != null)
        {
            yield return $"--reference-location={ReferenceLocation}";
        }
        if (MarkdownHeadings != null)
        {
            yield return $"--markdown-headings={MarkdownHeadings}";
        }
    }
}
```


#### MarkdownHeadings

```cs
public enum MarkdownHeadings
{
    Setext,
    Atx
}
```


#### MdStrictOut

```cs
/// <summary>
/// https://daringfireball.net/projects/markdown/
/// </summary>
public class MdStrictOut :
    OutOptions
{
    public override string Format => "markdown_strict";

    /// <summary>
    /// Use only ASCII characters in output
    /// https://pandoc.org/MANUAL.html#option--ascii
    /// </summary>
    public bool Ascii { get; set; }
    /// <summary>
    /// Use reference-style links, rather than inline links
    /// https://pandoc.org/MANUAL.html#option--reference-links
    /// </summary>
    public bool ReferenceLinks { get; set; }
    /// <summary>
    /// Specify whether footnotes (and references, if reference-links is set) are placed at the end of the current (top-level) block, the current section, or the document.
    /// https://pandoc.org/MANUAL.html#option--reference-location
    /// </summary>
    public ReferenceLocation? ReferenceLocation { get; set; }
    /// <summary>
    /// Specify whether to use ATX-style (#-prefixed) or Setext-style (underlined) headings for level 1 and 2 headings in Markdown output
    /// https://pandoc.org/MANUAL.html#option--markdown-headings
    /// </summary>
    public MarkdownHeadings? MarkdownHeadings { get; set; }

    public override IEnumerable<string> GetArguments()
    {
        foreach (var argument in base.GetArguments())
        {
            yield return argument;
        }

        if (Ascii)
        {
            yield return "--ascii";
        }
        if (ReferenceLinks)
        {
            yield return "--reference-links";
        }
        if (ReferenceLocation != null)
        {
            yield return $"--reference-location={ReferenceLocation}";
        }
        if (MarkdownHeadings != null)
        {
            yield return $"--markdown-headings={MarkdownHeadings}";
        }
    }
}
```


#### MultiMdOut

```cs
/// <summary>
/// https://fletcherpenney.net/multimarkdown/
/// </summary>
public class MultiMdOut :
    OutOptions
{
    public override string Format => "markdown_mmd";

    /// <summary>
    /// Use only ASCII characters in output
    /// https://pandoc.org/MANUAL.html#option--ascii
    /// </summary>
    public bool Ascii { get; set; }
    /// <summary>
    /// Use reference-style links, rather than inline links
    /// https://pandoc.org/MANUAL.html#option--reference-links
    /// </summary>
    public bool ReferenceLinks { get; set; }
    /// <summary>
    /// Specify whether footnotes (and references, if reference-links is set) are placed at the end of the current (top-level) block, the current section, or the document.
    /// https://pandoc.org/MANUAL.html#option--reference-location
    /// </summary>
    public ReferenceLocation? ReferenceLocation { get; set; }
    /// <summary>
    /// Specify whether to use ATX-style (#-prefixed) or Setext-style (underlined) headings for level 1 and 2 headings in Markdown output
    /// https://pandoc.org/MANUAL.html#option--markdown-headings
    /// </summary>
    public MarkdownHeadings? MarkdownHeadings { get; set; }

    public override IEnumerable<string> GetArguments()
    {
        foreach (var argument in base.GetArguments())
        {
            yield return argument;
        }

        if (Ascii)
        {
            yield return "--ascii";
        }
        if (ReferenceLinks)
        {
            yield return "--reference-links";
        }
        if (ReferenceLocation != null)
        {
            yield return $"--reference-location={ReferenceLocation}";
        }
        if (MarkdownHeadings != null)
        {
            yield return $"--markdown-headings={MarkdownHeadings}";
        }
    }
}
```


#### PandocMdOut

```cs
/// <summary>
/// https://pandoc.org/MANUAL.html#pandocs-markdown
/// </summary>
public class PandocMdOut :
    OutOptions
{
    public override string Format => "markdown";

    /// <summary>
    /// Use only ASCII characters in output
    /// https://pandoc.org/MANUAL.html#option--ascii
    /// </summary>
    public bool Ascii { get; set; }
    /// <summary>
    /// Use reference-style links, rather than inline links
    /// https://pandoc.org/MANUAL.html#option--reference-links
    /// </summary>
    public bool ReferenceLinks { get; set; }
    /// <summary>
    /// Specify whether footnotes (and references, if reference-links is set) are placed at the end of the current (top-level) block, the current section, or the document.
    /// https://pandoc.org/MANUAL.html#option--reference-location
    /// </summary>
    public ReferenceLocation? ReferenceLocation { get; set; }
    /// <summary>
    /// Specify whether to use ATX-style (#-prefixed) or Setext-style (underlined) headings for level 1 and 2 headings in Markdown output
    /// https://pandoc.org/MANUAL.html#option--markdown-headings
    /// </summary>
    public MarkdownHeadings? MarkdownHeadings { get; set; }

    public override IEnumerable<string> GetArguments()
    {
        foreach (var argument in base.GetArguments())
        {
            yield return argument;
        }

        if (Ascii)
        {
            yield return "--ascii";
        }

        if (ReferenceLinks)
        {
            yield return "--reference-links";
        }
        if (ReferenceLocation != null)
        {
            yield return $"--reference-location={ReferenceLocation}";
        }
        if (MarkdownHeadings != null)
        {
            yield return $"--markdown-headings={MarkdownHeadings}";
        }
    }
}
```


#### PhpMdExtraOut

```cs
/// <summary>
/// https://michelf.ca/projects/php-markdown/extra/
/// </summary>
public class PhpMdExtraOut :
    OutOptions
{
    public override string Format => "markdown_phpextra";

    /// <summary>
    /// Use only ASCII characters in output
    /// https://pandoc.org/MANUAL.html#option--ascii
    /// </summary>
    public bool Ascii { get; set; }
    /// <summary>
    /// Use reference-style links, rather than inline links
    /// https://pandoc.org/MANUAL.html#option--reference-links
    /// </summary>
    public bool ReferenceLinks { get; set; }
    /// <summary>
    /// Specify whether footnotes (and references, if reference-links is set) are placed at the end of the current (top-level) block, the current section, or the document.
    /// https://pandoc.org/MANUAL.html#option--reference-location
    /// </summary>
    public ReferenceLocation? ReferenceLocation { get; set; }
    /// <summary>
    /// Specify whether to use ATX-style (#-prefixed) or Setext-style (underlined) headings for level 1 and 2 headings in Markdown output
    /// https://pandoc.org/MANUAL.html#option--markdown-headings
    /// </summary>
    public MarkdownHeadings? MarkdownHeadings { get; set; }

    public override IEnumerable<string> GetArguments()
    {
        foreach (var argument in base.GetArguments())
        {
            yield return argument;
        }

        if (Ascii)
        {
            yield return "--ascii";
        }

        if (ReferenceLinks)
        {
            yield return "--reference-links";
        }
        if (ReferenceLocation != null)
        {
            yield return $"--reference-location={ReferenceLocation}";
        }
        if (MarkdownHeadings != null)
        {
            yield return $"--markdown-headings={MarkdownHeadings}";
        }
    }
}
```


#### PdfEngine

```cs
public enum PdfEngine
{
    PdfLatex,
    LuaLatex,
    XeLatex,
    LatexMk,
    Tectonic,
    WkHtmlToPdf,
    WeasyPrint,
    Prince,
    Context,
    PdfRoff
}
```


#### PdfOut

```cs
/// <summary>
/// https://www.adobe.com/acrobat/about-adobe-pdf.html
/// </summary>
public class PdfOut :
    OutOptions
{
    public override string Format => "pdf";

    /// <summary>
    /// Specify the name of the engine to look for on the path.
    /// </summary>
    /// <remarks>
    /// 'EnginePath' takes precedence over this property.
    /// </remarks>
    public PdfEngine? Engine { get; set; }

    /// <summary>
    /// Specify the location of the engine.
    /// </summary>
    /// <remarks>
    /// This takes precedence over the 'Engine' property.
    /// </remarks>
    public string? EnginePath { get; set; }

    public override IEnumerable<string> GetArguments()
    {
        foreach (var argument in base.GetArguments())
        {
            yield return argument;
        }

        if (!string.IsNullOrEmpty(EnginePath))
        {
            yield return $"--pdf-engine={EnginePath}";
        }
        else if (Engine != null)
        {
            yield return $"--pdf-engine={Engine.Value.ToString().ToLower()}";
        }
    }
}
```


#### BeamerOut

```cs
/// <summary>
/// https://ctan.org/pkg/beamer
/// </summary>
public class BeamerOut :
    OutOptions
{
    public override string Format => "beamer";

    /// <summary>
    /// Produce a standalone HTML file with no external dependencies, using data: URIs to incorporate the contents of linked scripts, stylesheets, images, and videos
    /// https://pandoc.org/MANUAL.html#option--self-contained
    /// </summary>
    public bool SelfContained { get; set; }
    /// <summary>
    /// Use &lt;q&gt; tags for quotes in HTML. (This option only has an effect if the smart extension is enabled for the input format used.)
    /// https://pandoc.org/MANUAL.html#option--html-q-tags
    /// </summary>
    public bool HtmlQTags { get; set; }
    /// <summary>
    /// Make list items in slide shows display incrementally (one by one). The default is for lists to be displayed all at once.
    ///  https://pandoc.org/MANUAL.html#option--incremental
    /// </summary>
    public bool Incremental { get; set; }
    /// <summary>
    /// Specifies that headings with the specified level create slides
    /// https://pandoc.org/MANUAL.html#option--slide-level
    /// </summary>
    public int? SlideLevel { get; set; }
    /// <summary>
    /// Wrap sections in &lt;section&gt; tags (or &lt;div&gt; tags for html4), and attach identifiers to the enclosing &lt;section> (or &lt;div&gt;) rather than the heading itself
    /// https://pandoc.org/MANUAL.html#option--section-divs
    /// </summary>
    public bool SectionDivs { get; set; }
    /// <summary>
    /// Use only ASCII characters in output
    /// https://pandoc.org/MANUAL.html#option--ascii
    /// </summary>
    public bool Ascii { get; set; }
    /// <summary>
    /// Specify whether footnotes (and references, if reference-links is set) are placed at the end of the current (top-level) block, the current section, or the document.
    /// https://pandoc.org/MANUAL.html#option--reference-location
    /// </summary>
    public ReferenceLocation? ReferenceLocation { get; set; }
    /// <summary>
    /// Specify STRING as a prefix at the beginning of the title that appears in the HTML header (but not in the title as it appears at the beginning of the HTML body).
    /// https://pandoc.org/MANUAL.html#option--id-prefix
    /// </summary>
    public string? IdPrefix { get; set; }
    /// <summary>
    /// Link to a CSS style sheet. This option can be used repeatedly to include multiple files. They will be included in the order specified.
    /// https://pandoc.org/MANUAL.html#option--css
    /// </summary>
    public string? Css { get; set; }
    /// <summary>
    /// Specify STRING as a prefix at the beginning of the title that appears in the HTML header (but not in the title as it appears at the beginning of the HTML body).
    /// https://pandoc.org/MANUAL.html#option--title-prefix
    /// </summary>
    public string? TitlePrefix { get; set; }

    public override IEnumerable<string> GetArguments()
    {
        foreach (var argument in base.GetArguments())
        {
            yield return argument;
        }

        if (SelfContained)
        {
            yield return "--self-contained";
        }

        if (Ascii)
        {
            yield return "--ascii";
        }

        if (HtmlQTags)
        {
            yield return "--html-q-tags";
        }
        if (ReferenceLocation != null)
        {
            yield return $"--reference-location={ReferenceLocation}";
        }
        if (SlideLevel != null)
        {
            yield return $"--slide-level={SlideLevel}";
        }
        if (Incremental)
        {
            yield return "--incremental";
        }
        if (SectionDivs)
        {
            yield return "--section-divs";
        }
        if (IdPrefix != null)
        {
            yield return $"--id-prefix={IdPrefix}";
        }
        if (Css != null)
        {
            yield return $"--css={Css}";
        }
        if (TitlePrefix != null)
        {
            yield return $"--title-prefix={TitlePrefix}";
        }
    }
}
```


#### DzSlidesOut

```cs
/// <summary>
/// https://paulrouget.com/dzslides/
/// </summary>
public class DzSlidesOut :
    OutOptions
{
    public override string Format => "dzslides";

    /// <summary>
    /// Produce a standalone HTML file with no external dependencies, using data: URIs to incorporate the contents of linked scripts, stylesheets, images, and videos
    /// https://pandoc.org/MANUAL.html#option--self-contained
    /// </summary>
    public bool SelfContained { get; set; }
    /// <summary>
    /// Use &lt;q&gt; tags for quotes in HTML. (This option only has an effect if the smart extension is enabled for the input format used.)
    /// https://pandoc.org/MANUAL.html#option--html-q-tags
    /// </summary>
    public bool HtmlQTags { get; set; }
    /// <summary>
    /// Make list items in slide shows display incrementally (one by one). The default is for lists to be displayed all at once.
    ///  https://pandoc.org/MANUAL.html#option--incremental
    /// </summary>
    public bool Incremental { get; set; }
    /// <summary>
    /// Specifies that headings with the specified level create slides
    /// https://pandoc.org/MANUAL.html#option--slide-level
    /// </summary>
    public int? SlideLevel { get; set; }
    /// <summary>
    /// Use only ASCII characters in output
    /// https://pandoc.org/MANUAL.html#option--ascii
    /// </summary>
    public bool Ascii { get; set; }
    /// <summary>
    /// Wrap sections in &lt;section&gt; tags (or &lt;div&gt; tags for html4), and attach identifiers to the enclosing &lt;section> (or &lt;div&gt;) rather than the heading itself
    /// https://pandoc.org/MANUAL.html#option--section-divs
    /// </summary>
    public bool SectionDivs { get; set; }
    /// <summary>
    /// Specify whether footnotes (and references, if reference-links is set) are placed at the end of the current (top-level) block, the current section, or the document.
    /// https://pandoc.org/MANUAL.html#option--reference-location
    /// </summary>
    public ReferenceLocation? ReferenceLocation { get; set; }
    /// <summary>
    /// Specify STRING as a prefix at the beginning of the title that appears in the HTML header (but not in the title as it appears at the beginning of the HTML body).
    /// https://pandoc.org/MANUAL.html#option--id-prefix
    /// </summary>
    public string? IdPrefix { get; set; }
    /// <summary>
    /// Link to a CSS style sheet. This option can be used repeatedly to include multiple files. They will be included in the order specified.
    /// https://pandoc.org/MANUAL.html#option--css
    /// </summary>
    public string? Css { get; set; }
    /// <summary>
    /// Specify STRING as a prefix at the beginning of the title that appears in the HTML header (but not in the title as it appears at the beginning of the HTML body).
    /// https://pandoc.org/MANUAL.html#option--title-prefix
    /// </summary>
    public string? TitlePrefix { get; set; }

    public override IEnumerable<string> GetArguments()
    {
        foreach (var argument in base.GetArguments())
        {
            yield return argument;
        }

        if (SelfContained)
        {
            yield return "--self-contained";
        }

        if (Ascii)
        {
            yield return "--ascii";
        }

        if (HtmlQTags)
        {
            yield return "--html-q-tags";
        }
        if (ReferenceLocation != null)
        {
            yield return $"--reference-location={ReferenceLocation}";
        }
        if (SlideLevel != null)
        {
            yield return $"--slide-level={SlideLevel}";
        }
        if (SectionDivs)
        {
            yield return "--section-divs";
        }
        if (Incremental)
        {
            yield return "--incremental";
        }
        if (IdPrefix != null)
        {
            yield return $"--id-prefix={IdPrefix}";
        }
        if (Css != null)
        {
            yield return $"--css={Css}";
        }
        if (TitlePrefix != null)
        {
            yield return $"--title-prefix={TitlePrefix}";
        }
    }
}
```


#### PptxOut

```cs
/// <summary>
/// https://en.wikipedia.org/wiki/Microsoft_PowerPoint
/// </summary>
public class PptxOut :
    OutOptions
{
    public override string Format => "pptx";

    /// <summary>
    /// Use the specified file as a style reference in producing
    /// https://pandoc.org/MANUAL.html#option--reference-doc
    /// </summary>
    public string? ReferenceDoc { get; set; }

    public override IEnumerable<string> GetArguments()
    {
        foreach (var argument in base.GetArguments())
        {
            yield return argument;
        }

        if (ReferenceDoc != null)
        {
            yield return $"--reference-doc={ReferenceDoc}";
        }
    }
}
```


#### RevealJsOut

```cs
/// <summary>
/// https://revealjs.com/
/// </summary>
public class RevealJsOut :
    OutOptions
{
    public override string Format => "revealjs";

    /// <summary>
    /// Produce a standalone HTML file with no external dependencies, using data: URIs to incorporate the contents of linked scripts, stylesheets, images, and videos
    /// https://pandoc.org/MANUAL.html#option--self-contained
    /// </summary>
    public bool SelfContained { get; set; }
    /// <summary>
    /// Use &lt;q&gt; tags for quotes in HTML. (This option only has an effect if the smart extension is enabled for the input format used.)
    /// https://pandoc.org/MANUAL.html#option--html-q-tags
    /// </summary>
    public bool HtmlQTags { get; set; }
    /// <summary>
    /// Wrap sections in &lt;section&gt; tags (or &lt;div&gt; tags for html4), and attach identifiers to the enclosing &lt;section> (or &lt;div&gt;) rather than the heading itself
    /// https://pandoc.org/MANUAL.html#option--section-divs
    /// </summary>
    public bool SectionDivs { get; set; }
    /// <summary>
    /// Use only ASCII characters in output
    /// https://pandoc.org/MANUAL.html#option--ascii
    /// </summary>
    public bool Ascii { get; set; }
    /// <summary>
    /// Specify whether footnotes (and references, if reference-links is set) are placed at the end of the current (top-level) block, the current section, or the document.
    /// https://pandoc.org/MANUAL.html#option--reference-location
    /// </summary>
    public ReferenceLocation? ReferenceLocation { get; set; }
    /// <summary>
    /// Specify STRING as a prefix at the beginning of the title that appears in the HTML header (but not in the title as it appears at the beginning of the HTML body).
    /// https://pandoc.org/MANUAL.html#option--id-prefix
    /// </summary>
    public string? IdPrefix { get; set; }
    /// <summary>
    /// Link to a CSS style sheet. This option can be used repeatedly to include multiple files. They will be included in the order specified.
    /// https://pandoc.org/MANUAL.html#option--css
    /// </summary>
    public string? Css { get; set; }
    /// <summary>
    /// Specify STRING as a prefix at the beginning of the title that appears in the HTML header (but not in the title as it appears at the beginning of the HTML body).
    /// https://pandoc.org/MANUAL.html#option--title-prefix
    /// </summary>
    public string? TitlePrefix { get; set; }

    public override IEnumerable<string> GetArguments()
    {
        foreach (var argument in base.GetArguments())
        {
            yield return argument;
        }

        if (SelfContained)
        {
            yield return "--self-contained";
        }

        if (Ascii)
        {
            yield return "--ascii";
        }

        if (HtmlQTags)
        {
            yield return "--html-q-tags";
        }
        if (SectionDivs)
        {
            yield return "--section-divs";
        }
        if (ReferenceLocation != null)
        {
            yield return $"--reference-location={ReferenceLocation}";
        }
        if (IdPrefix != null)
        {
            yield return $"--id-prefix={IdPrefix}";
        }
        if (Css != null)
        {
            yield return $"--css={Css}";
        }
        if (TitlePrefix != null)
        {
            yield return $"--title-prefix={TitlePrefix}";
        }
    }
}
```


#### S5Out

```cs
/// <summary>
/// https://meyerweb.com/eric/tools/s5/
/// </summary>
public class S5Out :
    OutOptions
{
    public override string Format => "s5";

    /// <summary>
    /// Produce a standalone HTML file with no external dependencies, using data: URIs to incorporate the contents of linked scripts, stylesheets, images, and videos
    /// https://pandoc.org/MANUAL.html#option--self-contained
    /// </summary>
    public bool SelfContained { get; set; }
    /// <summary>
    /// Use &lt;q&gt; tags for quotes in HTML. (This option only has an effect if the smart extension is enabled for the input format used.)
    /// https://pandoc.org/MANUAL.html#option--html-q-tags
    /// </summary>
    public bool HtmlQTags { get; set; }
    /// <summary>
    /// Use only ASCII characters in output
    /// https://pandoc.org/MANUAL.html#option--ascii
    /// </summary>
    public bool Ascii { get; set; }
    /// <summary>
    /// Specifies that headings with the specified level create slides
    /// https://pandoc.org/MANUAL.html#option--slide-level
    /// </summary>
    public int? SlideLevel { get; set; }
    /// <summary>
    /// Wrap sections in &lt;section&gt; tags (or &lt;div&gt; tags for html4), and attach identifiers to the enclosing &lt;section> (or &lt;div&gt;) rather than the heading itself
    /// https://pandoc.org/MANUAL.html#option--section-divs
    /// </summary>
    public bool SectionDivs { get; set; }
    /// <summary>
    /// Specify whether footnotes (and references, if reference-links is set) are placed at the end of the current (top-level) block, the current section, or the document.
    /// https://pandoc.org/MANUAL.html#option--reference-location
    /// </summary>
    public ReferenceLocation? ReferenceLocation { get; set; }
    /// <summary>
    /// Specify STRING as a prefix at the beginning of the title that appears in the HTML header (but not in the title as it appears at the beginning of the HTML body).
    /// https://pandoc.org/MANUAL.html#option--id-prefix
    /// </summary>
    public string? IdPrefix { get; set; }
    /// <summary>
    /// Link to a CSS style sheet. This option can be used repeatedly to include multiple files. They will be included in the order specified.
    /// https://pandoc.org/MANUAL.html#option--css
    /// </summary>
    public string? Css { get; set; }
    /// <summary>
    /// Specify STRING as a prefix at the beginning of the title that appears in the HTML header (but not in the title as it appears at the beginning of the HTML body).
    /// https://pandoc.org/MANUAL.html#option--title-prefix
    /// </summary>
    public string? TitlePrefix { get; set; }

    public override IEnumerable<string> GetArguments()
    {
        foreach (var argument in base.GetArguments())
        {
            yield return argument;
        }

        if (SelfContained)
        {
            yield return "--self-contained";
        }

        if (Ascii)
        {
            yield return "--ascii";
        }

        if (HtmlQTags)
        {
            yield return "--html-q-tags";
        }
        if (SlideLevel != null)
        {
            yield return $"--slide-level={SlideLevel}";
        }
        if (SectionDivs)
        {
            yield return "--section-divs";
        }
        if (ReferenceLocation != null)
        {
            yield return $"--reference-location={ReferenceLocation}";
        }
        if (IdPrefix != null)
        {
            yield return $"--id-prefix={IdPrefix}";
        }
        if (Css != null)
        {
            yield return $"--css={Css}";
        }
        if (TitlePrefix != null)
        {
            yield return $"--title-prefix={TitlePrefix}";
        }
    }
}
```


#### SlideousOut

```cs
/// <summary>
/// https://goessner.net/articles/slideous/
/// </summary>
public class SlideousOut :
    OutOptions
{
    public override string Format => "slideous";

    /// <summary>
    /// Produce a standalone HTML file with no external dependencies, using data: URIs to incorporate the contents of linked scripts, stylesheets, images, and videos
    /// https://pandoc.org/MANUAL.html#option--self-contained
    /// </summary>
    public bool SelfContained { get; set; }
    /// <summary>
    /// Use &lt;q&gt; tags for quotes in HTML. (This option only has an effect if the smart extension is enabled for the input format used.)
    /// https://pandoc.org/MANUAL.html#option--html-q-tags
    /// </summary>
    public bool HtmlQTags { get; set; }
    /// <summary>
    /// Use only ASCII characters in output
    /// https://pandoc.org/MANUAL.html#option--ascii
    /// </summary>
    public bool Ascii { get; set; }
    /// <summary>
    /// Wrap sections in &lt;section&gt; tags (or &lt;div&gt; tags for html4), and attach identifiers to the enclosing &lt;section> (or &lt;div&gt;) rather than the heading itself
    /// https://pandoc.org/MANUAL.html#option--section-divs
    /// </summary>
    public bool SectionDivs { get; set; }
    /// <summary>
    /// Specifies that headings with the specified level create slides
    /// https://pandoc.org/MANUAL.html#option--slide-level
    /// </summary>
    public int? SlideLevel { get; set; }
    /// <summary>
    /// Specify STRING as a prefix at the beginning of the title that appears in the HTML header (but not in the title as it appears at the beginning of the HTML body).
    /// https://pandoc.org/MANUAL.html#option--id-prefix
    /// </summary>
    public string? IdPrefix { get; set; }
    /// <summary>
    /// Specify whether footnotes (and references, if reference-links is set) are placed at the end of the current (top-level) block, the current section, or the document.
    /// https://pandoc.org/MANUAL.html#option--reference-location
    /// </summary>
    public ReferenceLocation? ReferenceLocation { get; set; }
    /// <summary>
    /// Link to a CSS style sheet. This option can be used repeatedly to include multiple files. They will be included in the order specified.
    /// https://pandoc.org/MANUAL.html#option--css
    /// </summary>
    public string? Css { get; set; }
    /// <summary>
    /// Specify STRING as a prefix at the beginning of the title that appears in the HTML header (but not in the title as it appears at the beginning of the HTML body).
    /// https://pandoc.org/MANUAL.html#option--title-prefix
    /// </summary>
    public string? TitlePrefix { get; set; }

    public override IEnumerable<string> GetArguments()
    {
        foreach (var argument in base.GetArguments())
        {
            yield return argument;
        }

        if (SelfContained)
        {
            yield return "--self-contained";
        }

        if (Ascii)
        {
            yield return "--ascii";
        }

        if (HtmlQTags)
        {
            yield return "--html-q-tags";
        }
        if (SlideLevel != null)
        {
            yield return $"--slide-level={SlideLevel}";
        }
        if (SectionDivs)
        {
            yield return "--section-divs";
        }
        if (ReferenceLocation != null)
        {
            yield return $"--reference-location={ReferenceLocation}";
        }
        if (IdPrefix != null)
        {
            yield return $"--id-prefix={IdPrefix}";
        }
        if (Css != null)
        {
            yield return $"--css={Css}";
        }
        if (TitlePrefix != null)
        {
            yield return $"--title-prefix={TitlePrefix}";
        }
    }
}
```


#### SlidyOut

```cs
/// <summary>
/// https://www.w3.org/Talks/Tools/Slidy2/
/// </summary>
public class SlidyOut :
    OutOptions
{
    public override string Format => "slidy";

    /// <summary>
    /// Produce a standalone HTML file with no external dependencies, using data: URIs to incorporate the contents of linked scripts, stylesheets, images, and videos
    /// https://pandoc.org/MANUAL.html#option--self-contained
    /// </summary>
    public bool SelfContained { get; set; }
    /// <summary>
    /// Use &lt;q&gt; tags for quotes in HTML. (This option only has an effect if the smart extension is enabled for the input format used.)
    /// https://pandoc.org/MANUAL.html#option--html-q-tags
    /// </summary>
    public bool HtmlQTags { get; set; }
    /// <summary>
    /// Use only ASCII characters in output
    /// https://pandoc.org/MANUAL.html#option--ascii
    /// </summary>
    public bool Ascii { get; set; }
    /// <summary>
    /// Wrap sections in &lt;section&gt; tags (or &lt;div&gt; tags for html4), and attach identifiers to the enclosing &lt;section> (or &lt;div&gt;) rather than the heading itself
    /// https://pandoc.org/MANUAL.html#option--section-divs
    /// </summary>
    public bool SectionDivs { get; set; }
    /// <summary>
    /// Specifies that headings with the specified level create slides
    /// https://pandoc.org/MANUAL.html#option--slide-level
    /// </summary>
    public int? SlideLevel { get; set; }
    /// <summary>
    /// Specify whether footnotes (and references, if reference-links is set) are placed at the end of the current (top-level) block, the current section, or the document.
    /// https://pandoc.org/MANUAL.html#option--reference-location
    /// </summary>
    public ReferenceLocation? ReferenceLocation { get; set; }
    /// <summary>
    /// Specify STRING as a prefix at the beginning of the title that appears in the HTML header (but not in the title as it appears at the beginning of the HTML body).
    /// https://pandoc.org/MANUAL.html#option--id-prefix
    /// </summary>
    public string? IdPrefix { get; set; }
    /// <summary>
    /// Link to a CSS style sheet. This option can be used repeatedly to include multiple files. They will be included in the order specified.
    /// https://pandoc.org/MANUAL.html#option--css
    /// </summary>
    public string? Css { get; set; }
    /// <summary>
    /// Specify STRING as a prefix at the beginning of the title that appears in the HTML header (but not in the title as it appears at the beginning of the HTML body).
    /// https://pandoc.org/MANUAL.html#option--title-prefix
    /// </summary>
    public string? TitlePrefix { get; set; }

    public override IEnumerable<string> GetArguments()
    {
        foreach (var argument in base.GetArguments())
        {
            yield return argument;
        }

        if (SelfContained)
        {
            yield return "--self-contained";
        }

        if (Ascii)
        {
            yield return "--ascii";
        }

        if (HtmlQTags)
        {
            yield return "--html-q-tags";
        }
        if (SectionDivs)
        {
            yield return "--section-divs";
        }

        if (SlideLevel != null)
        {
            yield return $"--slide-level={SlideLevel}";
        }
        if (SectionDivs)
        {
            yield return "--section-divs";
        }
        if (ReferenceLocation != null)
        {
            yield return $"--reference-location={ReferenceLocation}";
        }
        if (IdPrefix != null)
        {
            yield return $"--id-prefix={IdPrefix}";
        }
        if (Css != null)
        {
            yield return $"--css={Css}";
        }
        if (TitlePrefix != null)
        {
            yield return $"--title-prefix={TitlePrefix}";
        }
    }
}
```

<!-- endInclude -->


## Icon

[Pan Flute](https://thenounproject.com/term/pan+flute/1526666/) designed by [Creaticca Creative Agency](https://thenounproject.com/creaticca/) from [The Noun Project](https://thenounproject.com/).
