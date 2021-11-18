using CliWrap;
using VerifyNUnit;
using NUnit.Framework;
using PandocNet;

[TestFixture]
public class Samples
{
    [Test]
    public async Task MdToHtml()
    {
        var engine = new PandocEngine();
        await engine.Convert(
            new CommonMarkInput("sample.md"),
            new HtmlOutput("output.html"));

        await Verifier.VerifyFile("output.html");
    }
}