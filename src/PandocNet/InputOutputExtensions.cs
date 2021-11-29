using CliWrap;
using Replicant;

namespace Pandoc;

static class InputOutputExtensions
{
    public static PipeSource GetPipeSource(this Input input)
    {
        if (input.IsFile)
        {
            return PipeSource.FromFile(input.File);
        }

        if (input.IsStream)
        {
            return PipeSource.FromStream(input.Stream);
        }

        if (input.IsBytes)
        {
            return PipeSource.FromBytes(input.Bytes);
        }

        if (input.IsUrl)
        {
            var stream = HttpCache.Default.Stream(input.Url);
            return PipeSource.FromStream(stream);
        }

        if (input.IsContent)
        {
            return PipeSource.FromString(input.Content);
        }

        throw new("Unknown output");
    }

    public static PipeTarget GetPipeTarget(this Output output)
    {
        if (output.IsStringBuilder)
        {
            return PipeTarget.ToStringBuilder(output.StringBuilder);
        }

        if (output.IsFile)
        {
            File.Delete(output.File);
            return PipeTarget.ToFile(output.File);
        }

        if (output.IsStream)
        {
            return PipeTarget.ToStream(output.Stream);
        }

        throw new("Unknown output");
    }
}