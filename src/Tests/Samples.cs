using CliWrap;
using VerifyNUnit;
using NUnit.Framework;
using PandocNet;

[TestFixture]
public class Samples
{
    [Test]
    public async Task Files()
    {
        var engine = new PandocEngine();
        await engine.ConvertFile<CommonMarkIn, HtmlOut>("sample.md", "output.html");

        await Verifier.VerifyFile("output.html");
    }

    [Test]
    public async Task Streams()
    {
        {
            var engine = new PandocEngine();
            await using var inStream = File.OpenRead("sample.md");
            await using var outStream = File.OpenWrite("output.html");
            await engine.Convert<CommonMarkIn, HtmlOut>(
                inStream,
                outStream);
        }

        await Verifier.VerifyFile("output.html");
    }

    [Test]
    public async Task Content()
    {
        var engine = new PandocEngine();
        var result = await engine.ConvertContent<CommonMarkIn, HtmlOut>("*text*");

        await Verifier.Verify(result).UseExtension("html");
    }

    [Test]
    public async Task CustomOptions()
    {
        var engine = new PandocEngine();
        var result = await engine.ConvertContent(@"
# Heading1

text

## Heading2 

text
",
            new CommonMarkIn
            {
                ShiftHeadingLevelBy = 2
            },
            new HtmlOut
            {
                NumberOffsets = new List<int> {3}
            });

        await Verifier.Verify(result).UseExtension("html");
    }
}