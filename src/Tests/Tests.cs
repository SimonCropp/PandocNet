using VerifyNUnit;
using NUnit.Framework;
using Pandoc;

[TestFixture]
public class Tests
{
    [Test]
    public async Task BinaryToText()
    {
        var result = await PandocInstance.ConvertFile("sample.docx", "output.html");

        await Verifier.VerifyFile("output.html")
            .AppendValue("command", result.Command);
    }

    [Test]
    public async Task RawFiles()
    {
        var result = await PandocInstance.ConvertFile("sample.md", "output.html");

        await Verifier.VerifyFile("output.html")
            .AppendValue("command", result.Command);
    }

    [Test]
    public async Task DataDirectory()
    {
        var result = await PandocInstance.ConvertFile(
            "sample.md", 
            "output.html",
            new Options
            {
                DataDirectory = Environment.CurrentDirectory
            });

        await Verifier.VerifyFile("output.html")
            .AppendValue("command", result.Command);
    }

    [Test]
    public async Task Files()
    {
        var result = await PandocInstance.ConvertFile<CommonMarkIn, HtmlOut>("sample.md", "output.html");

        await Verifier.VerifyFile("output.html")
            .AppendValue("command", result.Command);
    }

    [Test]
    public async Task Streams()
    {
        Result result;
        {
            await using var inStream = File.OpenRead("sample.md");
            await using var outStream = File.OpenWrite("output.html");
            result = await PandocInstance.Convert<CommonMarkIn, HtmlOut>(inStream, outStream);
        }

        await Verifier.VerifyFile("output.html")
            .AppendValue("command", result.Command);
    }

    [Test]
    public async Task Text()
    {
        var (command, value) = await PandocInstance.ConvertText<CommonMarkIn, HtmlOut>("*text*");

        await Verifier.Verify(value).UseExtension("html")
            .AppendValue("command", command);
    }

    [Test]
    public async Task CustomOptions()
    {
        var (command, value) = await PandocInstance.ConvertText(@"# Heading1",
            new CommonMarkIn
            {
                ShiftHeadingLevelBy = 2
            },
            new HtmlOut
            {
                NumberOffsets = new[] {3}
            });

        await Verifier.Verify(value).UseExtension("html")
            .AppendValue("command", command);
    }
}