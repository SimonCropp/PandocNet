namespace Pandoc;

public class Output
{
    string? file;
    StringBuilder? stringBuilder;
    Stream? stream;

    public Output(string file) =>
        this.file = file;

    public Output(Stream stream) =>
        this.stream = stream;

    public Output(StringBuilder stringBuilder) =>
        this.stringBuilder = stringBuilder;

    public static implicit operator Output(string value) => new(value);
    public static implicit operator Output(Stream stream) => new(stream);
    public static implicit operator Output(StringBuilder stringBuilder) => new(stringBuilder);

    public PipeTarget GetPipeTarget()
    {
        if (stringBuilder != null)
        {
            return PipeTarget.ToStringBuilder(stringBuilder);
        }

        if (file != null)
        {
            File.Delete(file);
            return PipeTarget.ToFile(file);
        }

        if (stream != null)
        {
            return PipeTarget.ToStream(stream);
        }

        throw new("Unknown output");
    }
}