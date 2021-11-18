using CliWrap;

namespace PandocNet;

public class PandocEngine
{
    public async Task Convert(InputOptions input, OutputOptions output)
    {
        var errors = new StringBuilder();
        var command = Cli.Wrap("pandoc.exe")

            .WithArguments($"--from {input.Format} ")
            .WithArguments(input.GetArguments())

            // Force binary to stdout https://pandoc.org/MANUAL.html#option--output
            .WithArguments("-o -")

            .WithArguments($"--to {output.Format}")
            .WithArguments(output.GetArguments())

            .WithStandardErrorPipe(PipeTarget.ToStringBuilder(errors));
        try
        {
            var result = await (input.Stream | command | output.Stream)
                .ExecuteAsync();
            CheckErrorCodes(result, errors);
        }
        finally
        {
            input.Dispose();
            output.Dispose();
        }
    }

    static void CheckErrorCodes(CommandResult result, StringBuilder errors)
    {
        var exitCode = result.ExitCode;
        //https://pandoc.org/MANUAL.html#exit-codes
        if (exitCode == 3)
        {
            throw new($"PandocFailOnWarningError ({exitCode}): {errors}");
        }

        if (exitCode == 4)
        {
            throw new($"PandocAppError ({exitCode}): {errors}");
        }

        if (exitCode == 5)
        {
            throw new($"PandocTemplateError ({exitCode}): {errors}");
        }

        if (exitCode == 6)
        {
            throw new($"PandocOptionError ({exitCode}): {errors}");
        }

        if (exitCode == 21)
        {
            throw new($"PandocUnknownReaderError ({exitCode}): {errors}");
        }

        if (exitCode == 22)
        {
            throw new($"PandocUnknownWriterError ({exitCode}): {errors}");
        }

        if (exitCode == 24)
        {
            throw new($"PandocCiteprocError ({exitCode}): {errors}");
        }

        if (exitCode == 25)
        {
            throw new($"PandocBibliographyError ({exitCode}): {errors}");
        }

        if (exitCode == 31)
        {
            throw new($"PandocEpubSubdirectoryError ({exitCode}): {errors}");
        }

        if (exitCode == 43)
        {
            throw new($"PandocPDFError ({exitCode}): {errors}");
        }

        if (exitCode == 44)
        {
            throw new($"PandocXMLError ({exitCode}): {errors}");
        }

        if (exitCode == 47)
        {
            throw new($"PandocPDFProgramNotFoundError: {errors}");
        }

        if (exitCode == 61)
        {
            throw new($"PandocHttpError ({exitCode}): {errors}");
        }

        if (exitCode == 62)
        {
            throw new($"PandocShouldNeverHappenError ({exitCode}): {errors}");
        }

        if (exitCode == 63)
        {
            throw new($"PandocSomeError ({exitCode}): {errors}");
        }

        if (exitCode == 64)
        {
            throw new("PandocParseError ({exitCode}): {errors}");
        }

        if (exitCode == 65)
        {
            throw new($"PandocParsecError ({exitCode}): {errors}");
        }

        if (exitCode == 67)
        {
            throw new($"PandocSyntaxMapError ({exitCode}): {errors}");
        }

        if (exitCode == 83)
        {
            throw new($"PandocFilterError ({exitCode}): {errors}");
        }

        if (exitCode == 91)
        {
            throw new($"PandocMacroLoop ({exitCode}): {errors}");
        }

        if (exitCode == 92)
        {
            throw new($"PandocUTF8DecodingError ({exitCode}): {errors}");
        }

        if (exitCode == 93)
        {
            throw new($"PandocIpynbDecodingError ({exitCode}): {errors}");
        }

        if (exitCode == 94)
        {
            throw new($"PandocUnsupportedCharsetError ({exitCode}): {errors}");
        }

        if (exitCode == 97)
        {
            throw new($"PandocCouldNotFindDataFileError ({exitCode}): {errors}");
        }

        if (exitCode == 99)
        {
            throw new($"PandocResourceNotFound ({exitCode}): {errors}");
        }
        if (exitCode != 0)
        {
            throw new($"PandocUnknownError ({exitCode}): {errors}");
        }
    }
}