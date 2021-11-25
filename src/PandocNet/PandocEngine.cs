using CliWrap;

namespace Pandoc;

public class PandocEngine
{
    internal string pandocPath;

    public PandocEngine(string? pandocPath = null)
    {
        this.pandocPath = pandocPath ?? "pandoc.exe";
    }

    public virtual async Task<Result> ConvertFile(
        string inFile,
        string outFile,
        Options? options = null,
        CancellationToken cancellation = default)
    {
        File.Delete(outFile);
        var errors = new StringBuilder();

        var arguments = new List<string>(Options.GetArguments(options))
        {
            $"--output={outFile}",
            inFile
        };
        var command = Cli.Wrap(pandocPath)
            .WithArguments(arguments)
            .WithStandardErrorPipe(PipeTarget.ToStringBuilder(errors))
            .WithValidation(CommandResultValidation.None);

        var result = await command.ExecuteAsync(cancellation);
        CheckErrorCodes(result, errors, command);
        return new(command.ToString());
    }

    public virtual async Task<Result> ConvertFile<TIn, TOut>(
        string inFile,
        string outFile,
        TIn? inOptions = null,
        TOut? outOptions = null,
        Options? options = null,
        CancellationToken cancellation = default)
        where TIn : InOptions, new()
        where TOut : OutOptions, new()
    {
        File.Delete(outFile);
        inOptions ??= new();
        outOptions ??= new();
        var errors = new StringBuilder();

        var arguments = new List<string>(Options.GetArguments(options));
        arguments.AddRange(inOptions.GetArguments());
        arguments.Add($"--output={outFile}");
        arguments.AddRange(outOptions.GetArguments());
        arguments.Add(inFile);
        var command = Cli.Wrap(pandocPath)
            .WithArguments(arguments)
            .WithStandardErrorPipe(PipeTarget.ToStringBuilder(errors))
            .WithValidation(CommandResultValidation.None);

        var result = await command.ExecuteAsync(cancellation);
        CheckErrorCodes(result, errors, command);
        return new(command.ToString());
    }

    public virtual async Task<StringResult> ConvertText<TIn, TOut>(
        string content,
        TIn? inOptions = null,
        TOut? outOptions = null,
        Options? options = null,
        CancellationToken cancellation = default)
        where TIn : InOptions, new()
        where TOut : OutOptions, new()
    {
        inOptions ??= new();
        outOptions ??= new();
        var errors = new StringBuilder();
        var output = new StringBuilder();

        var arguments = new List<string>(Options.GetArguments(options));
        arguments.AddRange(inOptions.GetArguments());
        arguments.AddRange(outOptions.GetArguments());
        var command = Cli.Wrap(pandocPath)
            .WithArguments(arguments)
            .WithStandardInputPipe(PipeSource.FromString(content))
            .WithStandardErrorPipe(PipeTarget.ToStringBuilder(errors))
            .WithStandardOutputPipe(PipeTarget.ToStringBuilder(output))
            .WithValidation(CommandResultValidation.None);

        var result = await command.ExecuteAsync(cancellation);
        CheckErrorCodes(result, errors, command);
        return new(command.ToString(), output.ToString());
    }

    public virtual async Task<Result> Convert<TIn, TOut>(
        Stream inStream,
        Stream outStream,
        TIn? inOptions = null,
        TOut? outOptions = null,
        Options? options = null,
        CancellationToken cancellation = default)
        where TIn : InOptions, new()
        where TOut : OutOptions, new()
    {
        inOptions ??= new();
        outOptions ??= new();

        var errors = new StringBuilder();
        var arguments = new List<string>(Options.GetArguments(options))
        {
            // Force binary to stdout
            "--output=-"
        };
        arguments.AddRange(inOptions.GetArguments());
        arguments.AddRange(outOptions.GetArguments());
        var command = Cli.Wrap(pandocPath)
            .WithArguments(arguments)
            .WithStandardErrorPipe(PipeTarget.ToStringBuilder(errors))
            .WithValidation(CommandResultValidation.None);

        var result = await (inStream | command | outStream)
            .ExecuteAsync(cancellation);
        CheckErrorCodes(result, errors, command);
        return new(command.ToString());
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