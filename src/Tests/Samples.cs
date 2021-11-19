using VerifyNUnit;
using NUnit.Framework;
using Pandoc;

[TestFixture]
public class Samples
{
    [Test]
    public async Task BinaryToText()
    {
        await PandocInstance.ConvertFile("sample.docx", "output.html");

        await Verifier.VerifyFile("output.html");
    }

    [Test]
    public async Task RawFiles()
    {
        #region RawFiles

        await PandocInstance.ConvertFile("sample.md", "output.html");

        #endregion

        await Verifier.VerifyFile("output.html");
    }

    [Test]
    public void PandocPath()
    {
        #region PandocPath

        var engine = new PandocEngine(@"D:\Tools\pandoc.exe");

        #endregion
    }

    [Test]
    public async Task Files()
    {
        #region files

        await PandocInstance.ConvertFile<CommonMarkIn, HtmlOut>("sample.md", "output.html");

        #endregion

        await Verifier.VerifyFile("output.html");
    }

    [Test]
    public async Task Streams()
    {
        {
            #region streams

            await using var inStream = File.OpenRead("sample.md");
            await using var outStream = File.OpenWrite("output.html");
            await PandocInstance.Convert<CommonMarkIn, HtmlOut>(inStream, outStream);

            #endregion
        }

        await Verifier.VerifyFile("output.html");
    }

    [Test]
    public async Task Text()
    {
        #region text

        var html = await PandocInstance.ConvertText<CommonMarkIn, HtmlOut>("*text*");

        #endregion

        await Verifier.Verify(html).UseExtension("html");
    }

    [Test]
    public async Task CustomOptions()
    {
        #region custom-options

        var html = await PandocInstance.ConvertText(@"
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

        #endregion

        await Verifier.Verify(html).UseExtension("html");
    }
}