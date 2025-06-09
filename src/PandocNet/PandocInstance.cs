namespace Pandoc;

public static class PandocInstance
{
    static PandocEngine instance = new();

    public static void SetPandocPath(string pandocPath) =>
        instance.pandocPath = pandocPath;

    public static Task<StringResult> ConvertToText<TIn, TOut>(
        string content,
        TIn? inOptions = null,
        TOut? outOptions = null,
        Options? options = null,
        Cancel cancel = default)
        where TIn : InOptions, new()
        where TOut : OutOptions, new() =>
        instance.ConvertToText(content, inOptions, outOptions, options, cancel);

    public static Task<StringResult> ConvertToText<TIn, TOut>(
        Input input,
        TIn? inOptions = null,
        TOut? outOptions = null,
        Options? options = null,
        Cancel cancel = default)
        where TIn : InOptions, new()
        where TOut : OutOptions, new() =>
        instance.ConvertToText(input, inOptions, outOptions, options, cancel);

    public static Task<Result> Convert<TIn, TOut>(
        Input input,
        Output output,
        TIn? inOptions = null,
        TOut? outOptions = null,
        Options? options = null,
        Cancel cancel = default)
        where TIn : InOptions, new()
        where TOut : OutOptions, new() =>
        instance.Convert(input, output, inOptions, outOptions, options, cancel);
}