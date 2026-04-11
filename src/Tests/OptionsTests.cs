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
}
