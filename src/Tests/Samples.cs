﻿using CliWrap;
using VerifyNUnit;
using NUnit.Framework;

[TestFixture]
public class Samples
{
    [Test]
    public async Task MdToHtml()
    {
        await using var input = File.OpenRead("sample.md");
        await using (var output = File.Create("output.html"))
        {
            await (input | Cli.Wrap("pandoc.exe")
                    .WithArguments("--from commonmark_x --to html") | output)
                .ExecuteAsync();
        }

        await Verifier.VerifyFile("output.html");
    }
}