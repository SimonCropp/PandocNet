using CliWrap;

namespace PandocNet;

public class PandocEngine
{
    public async Task<string> ConvertContent<TIn, TOut>(string content, TIn? inOptions = null, TOut? outOptions = null)
        where TIn : InOptions, new()
        where TOut : OutOptions, new()
    {
        inOptions ??= new TIn();
        outOptions ??= new TOut();
        var errors = new StringBuilder();
        var output = new StringBuilder();

        var arguments = new List<string>();
        arguments.AddRange(inOptions.GetArguments());
        arguments.AddRange(outOptions.GetArguments());
        var command = Cli.Wrap("pandoc.exe")
            .WithArguments(arguments)
            .WithStandardInputPipe(PipeSource.FromString(content))
            .WithStandardErrorPipe(PipeTarget.ToStringBuilder(errors))
            .WithStandardOutputPipe(PipeTarget.ToStringBuilder(output))
            .WithValidation(CommandResultValidation.None);

        var result = await command.ExecuteAsync();
        CheckErrorCodes(result, errors, command);
        return output.ToString();
    }

    public async Task Convert<TIn, TOut>(Stream inStream, Stream outStream, TIn? inOptions = null, TOut? outOptions = null)
        where TIn : InOptions, new()
        where TOut : OutOptions, new()
    {
        inOptions ??= new TIn();
        outOptions ??= new TOut();

        var errors = new StringBuilder();
        var arguments = new List<string>
        {
            // Force binary to stdout
            "-o -"
        };
        arguments.AddRange(inOptions.GetArguments());
        arguments.AddRange(outOptions.GetArguments());
        var command = Cli.Wrap("pandoc.exe")
            .WithArguments(arguments)
            .WithStandardErrorPipe(PipeTarget.ToStringBuilder(errors))
            .WithValidation(CommandResultValidation.None);

        var result = await (inStream | command | outStream)
            .ExecuteAsync();
        CheckErrorCodes(result, errors, command);
    }

    static void CheckErrorCodes(CommandResult result, StringBuilder errors, Command command)
    {
        var exitCode = result.ExitCode;

        if (exitCode == 0)
        {
            return;
        }

        var errorType = GetErrorType(exitCode);
        throw new($@"{errorType} ({exitCode}):
{command}
{errors}");
    }

    //https://pandoc.org/MANUAL.html#exit-codes
    static string GetErrorType(int exitCode)
    {
        return exitCode switch
        {
            3 => "PandocFailOnWarningError",
            4 => "PandocAppError",
            5 => "PandocTemplateError",
            6 => "PandocOptionError",
            21 => "PandocUnknownReaderError",
            22 => "PandocUnknownWriterError",
            24 => "PandocCiteprocError",
            25 => "PandocBibliographyError",
            31 => "PandocEpubSubdirectoryError",
            43 => "PandocPDFError",
            44 => "PandocXMLError",
            47 => "PandocPDFProgramNotFoundError",
            61 => "PandocHttpError",
            62 => "PandocShouldNeverHappenError",
            63 => "PandocSomeError",
            64 => "PandocParseError",
            65 => "PandocParsecError",
            67 => "PandocSyntaxMapError",
            83 => "PandocFilterError",
            91 => "PandocMacroLoop",
            92 => "PandocUTF8DecodingError",
            93 => "PandocIpynbDecodingError",
            94 => "PandocUnsupportedCharsetError",
            97 => "PandocCouldNotFindDataFileError",
            99 => "PandocResourceNotFound",
            _ => "PandocUnknownError"
        };
    }
}