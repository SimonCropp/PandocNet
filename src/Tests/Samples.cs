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
            new CommonMarkIn("sample.md"),
            new HtmlOut("output.html"));

        await Verifier.VerifyFile("output.html");
    }
}