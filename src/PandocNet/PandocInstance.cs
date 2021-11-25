namespace Pandoc;

public static class PandocInstance
{
    static PandocEngine instance = new();

    public static void SetPandocPath(string pandocPath)
    {
        instance.pandocPath = pandocPath;
    }

    public static Task<Result> ConvertFile(
        string inFile,
        string outFile,
        Options? options = null,
        CancellationToken cancellation = default)
    {
        return instance.ConvertFile(inFile, outFile, options, cancellation);
    }

    public static Task<Result> ConvertFile<TIn, TOut>(
        string inFile,
        string outFile,
        TIn? inOptions = null,
        TOut? outOptions = null,
        Options? options = null,
        CancellationToken cancellation = default)
        where TIn : InOptions, new()
        where TOut : OutOptions, new()
    {
        return instance.ConvertFile(inFile, outFile, inOptions, outOptions, options, cancellation);
    }

    public static Task<StringResult> ConvertText<TIn, TOut>(
        string content,
        TIn? inOptions = null,
        TOut? outOptions = null,
        Options? options = null,
        CancellationToken cancellation = default)
        where TIn : InOptions, new()
        where TOut : OutOptions, new()
    {
        return instance.ConvertText(content, inOptions, outOptions, options, cancellation);
    }

    public static Task<Result> Convert<TIn, TOut>(
        Stream inStream,
        Stream outStream,
        TIn? inOptions = null,
        TOut? outOptions = null,
        Options? options = null,
        CancellationToken cancellation = default)
        where TIn : InOptions, new()
        where TOut : OutOptions, new()
    {
        return instance.Convert(inStream, outStream, inOptions, outOptions, options, cancellation);
    }
}