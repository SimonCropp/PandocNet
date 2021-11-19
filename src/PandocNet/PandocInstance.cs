namespace Pandoc;

public static class PandocInstance
{
    static PandocEngine instance = new();

    public static void SetPandocPath(string pandocPath)
    {
        instance.pandocPath = pandocPath;
    }

    public static Task ConvertFile(string inFile, string outFile, CancellationToken cancellation = default)
    {
        return instance.ConvertFile(inFile, outFile, cancellation);
    }

    public static Task ConvertFile<TIn, TOut>(
        string inFile,
        string outFile,
        TIn? inOptions = null,
        TOut? outOptions = null,
        CancellationToken cancellation = default)
        where TIn : InOptions, new()
        where TOut : OutOptions, new()
    {
        return instance.ConvertFile(inFile, outFile,inOptions,outOptions,cancellation);
    }

    public static Task<string> ConvertText<TIn, TOut>(
        string content,
        TIn? inOptions = null,
        TOut? outOptions = null,
        CancellationToken cancellation = default)
        where TIn : InOptions, new()
        where TOut : OutOptions, new()
    {
        return instance.ConvertText(content, inOptions, outOptions, cancellation);
    }

    public static Task Convert<TIn, TOut>(
        Stream inStream,
        Stream outStream,
        TIn? inOptions = null,
        TOut? outOptions = null,
        CancellationToken cancellation = default)
        where TIn : InOptions, new()
        where TOut : OutOptions, new()
    {
        return instance.Convert(inStream, outStream, inOptions, outOptions, cancellation);
    }
}