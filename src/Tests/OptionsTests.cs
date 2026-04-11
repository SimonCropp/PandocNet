[TestFixture]
public class OptionsTests
{
    [Test]
    public void OutVariablesJson()
    {
        var options = new HtmlOut
        {
            VariablesJson = new Dictionary<string, string>
            {
                { "foo", "false" },
                { "colors", "[\"red\",\"green\"]" }
            }
        };

        var args = options.GetArguments().ToList();

        Assert.That(args, Does.Contain("--variable-json=foo:false"));
        Assert.That(args, Does.Contain("--variable-json=colors:[\"red\",\"green\"]"));
    }

    [Test]
    public void OutMetadata()
    {
        var options = new HtmlOut
        {
            Metadata = new Dictionary<string, string>
            {
                { "title", "My Document" },
                { "author", "Jane" }
            }
        };

        var args = options.GetArguments().ToList();

        Assert.That(args, Does.Contain("--metadata=title:My Document"));
        Assert.That(args, Does.Contain("--metadata=author:Jane"));
    }

    [Test]
    public void OutMetadataFile()
    {
        var options = new HtmlOut
        {
            MetadataFile = "meta.yaml"
        };

        var args = options.GetArguments().ToList();

        Assert.That(args, Does.Contain("--metadata-file=meta.yaml"));
    }

    [Test]
    public void OutVariables()
    {
        var options = new HtmlOut
        {
            Variables = new Dictionary<string, string>
            {
                { "margin-top", "1in" }
            }
        };

        var args = options.GetArguments().ToList();

        Assert.That(args, Does.Contain("--variable=margin-top:1in"));
    }

    [Test]
    public void InMetadata()
    {
        var options = new CommonMarkIn
        {
            Metadata = new Dictionary<string, string>
            {
                { "title", "Test" },
                { "draft", "true" }
            }
        };

        var args = options.GetArguments().ToList();

        Assert.That(args, Does.Contain("--metadata=title:Test"));
        Assert.That(args, Does.Contain("--metadata=draft:true"));
    }

    [Test]
    public void InMetadataFile()
    {
        var options = new CommonMarkIn
        {
            MetadataFile = "metadata.yaml"
        };

        var args = options.GetArguments().ToList();

        Assert.That(args, Does.Contain("--metadata-file=metadata.yaml"));
    }

    [Test]
    public void InFileScope()
    {
        var options = new CommonMarkIn
        {
            FileScope = true
        };

        var args = options.GetArguments().ToList();

        Assert.That(args, Does.Contain("--file-scope"));
    }

    [Test]
    public void InTrace()
    {
        var options = new CommonMarkIn
        {
            Trace = true
        };

        var args = options.GetArguments().ToList();

        Assert.That(args, Does.Contain("--trace"));
    }

    [Test]
    public void GlobalVerbose()
    {
        var args = Options.GetArguments(new Options { Verbose = true }).ToList();

        Assert.That(args, Does.Contain("--verbose"));
    }

    [Test]
    public void GlobalQuiet()
    {
        var args = Options.GetArguments(new Options { Quiet = true }).ToList();

        Assert.That(args, Does.Contain("--quiet"));
    }

    [Test]
    public void GlobalFailIfWarnings()
    {
        var args = Options.GetArguments(new Options { FailIfWarnings = true }).ToList();

        Assert.That(args, Does.Contain("--fail-if-warnings"));
    }

    [Test]
    public void OutListOfFigures()
    {
        var options = new HtmlOut
        {
            ListOfFigures = true
        };

        var args = options.GetArguments().ToList();

        Assert.That(args, Does.Contain("--list-of-figures"));
    }

    [Test]
    public void OutListOfTables()
    {
        var options = new HtmlOut
        {
            ListOfTables = true
        };

        var args = options.GetArguments().ToList();

        Assert.That(args, Does.Contain("--list-of-tables"));
    }

    [Test]
    public void OutFigureCaptionPosition()
    {
        var options = new HtmlOut
        {
            FigureCaptionPosition = CaptionPosition.Above
        };

        var args = options.GetArguments().ToList();

        Assert.That(args, Does.Contain("--figure-caption-position=above"));
    }

    [Test]
    public void OutTableCaptionPosition()
    {
        var options = new HtmlOut
        {
            TableCaptionPosition = CaptionPosition.Below
        };

        var args = options.GetArguments().ToList();

        Assert.That(args, Does.Contain("--table-caption-position=below"));
    }

    [Test]
    public void OutSyntaxHighlighting()
    {
        var options = new HtmlOut
        {
            SyntaxHighlighting = "kate"
        };

        var args = options.GetArguments().ToList();

        Assert.That(args, Does.Contain("--syntax-highlighting=kate"));
    }

    [Test]
    public void HtmlEmailObfuscation()
    {
        var options = new HtmlOut
        {
            EmailObfuscation = EmailObfuscation.Javascript
        };

        var args = options.GetArguments().ToList();

        Assert.That(args, Does.Contain("--email-obfuscation=javascript"));
    }

    [Test]
    public void RstListTables()
    {
        var options = new RstOut
        {
            ListTables = true
        };

        var args = options.GetArguments().ToList();

        Assert.That(args, Does.Contain("--list-tables"));
    }

    [Test]
    public void PdfEngineOpt()
    {
        var options = new PdfOut
        {
            Engine = PdfEngine.XeLatex,
            EngineOpt = "--shell-escape"
        };

        var args = options.GetArguments().ToList();

        Assert.That(args, Does.Contain("--pdf-engine=xelatex"));
        Assert.That(args, Does.Contain("--pdf-engine-opt=--shell-escape"));
    }

    [Test]
    public void EpubSplitLevel()
    {
        var options = new Epub3Out
        {
            SplitLevel = 2
        };

        var args = options.GetArguments().ToList();

        Assert.That(args, Does.Contain("--split-level=2"));
    }

    [Test]
    public void EpubTitlePage()
    {
        var options = new Epub3Out
        {
            EpubTitlePage = false
        };

        var args = options.GetArguments().ToList();

        Assert.That(args, Does.Contain("--epub-title-page=false"));
    }

    [Test]
    public void ChunkedHtmlSplitLevel()
    {
        var options = new ChunkedHtmlOut
        {
            SplitLevel = 3
        };

        var args = options.GetArguments().ToList();

        Assert.That(args, Does.Contain("--split-level=3"));
    }

    [Test]
    public void ChunkedHtmlChunkTemplate()
    {
        var options = new ChunkedHtmlOut
        {
            ChunkTemplate = "%s-%i.html"
        };

        var args = options.GetArguments().ToList();

        Assert.That(args, Does.Contain("--chunk-template=%s-%i.html"));
    }
}
