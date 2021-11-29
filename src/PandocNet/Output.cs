namespace Pandoc;

public class Output
{
    string? file;
    StringBuilder? stringBuilder;
    Stream? stream;

    public StringBuilder StringBuilder
    {
        get
        {
            if (!IsStringBuilder)
            {
                throw new("Not a stringBuilder");
            }

            return stringBuilder!;
        }
    }

    public string File
    {
        get
        {
            if (!IsFile)
            {
                throw new("Not a file");
            }

            return file!;
        }
    }

    public Stream Stream
    {
        get
        {
            if (!IsStream)
            {
                throw new("Not a stream");
            }

            return stream!;
        }
    }

    public Output(string file)
    {
        this.file = file;
    }

    public Output(Stream stream)
    {
        this.stream = stream;
    }

    public Output(StringBuilder stringBuilder)
    {
        this.stringBuilder = stringBuilder;
    }

    public bool IsStream
    {
        get => stream != null;
    }

    public bool IsStringBuilder
    {
        get => stringBuilder != null;
    }

    public bool IsFile
    {
        get => file != null;
    }

    public static implicit operator Output(string value) => new(value);
    public static implicit operator Output(Stream stream) => new(stream);
    public static implicit operator Output(StringBuilder stringBuilder) => new(stringBuilder);
}