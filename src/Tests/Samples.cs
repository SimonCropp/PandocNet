// ReSharper disable UnusedVariable

[TestFixture]
public class Samples
{
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

        await PandocInstance.Convert<CommonMarkIn, HtmlOut>("sample.md", "output.html");

        #endregion

        await VerifyFile("output.html");
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

        await VerifyFile("output.html");
    }

    [Test]
    public async Task Text()
    {
        #region text

        var html = await PandocInstance.ConvertToText<CommonMarkIn, HtmlOut>("*text*");

        #endregion

        await Verify(html.Value, "html");
    }

    [Test]
    public async Task CustomOptions()
    {
        #region custom-options

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

        #endregion

        await Verify(html.Value, "html");
    }
}