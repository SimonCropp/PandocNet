namespace Pandoc;

public class Input
{
    string? file;
    string? url;
    string? content;
    byte[]? bytes;
    Stream? stream;

    public Input(string value)
    {
        if (value.StartsWith("http://") ||
            value.StartsWith("https://"))
        {
            url = value;
            return;
        }

        if (System.IO.File.Exists(value))
        {
            file = value;
            return;
        }

        content = value;
    }

    public string Url
    {
        get
        {
            if (!IsUrl)
            {
                throw new("Not a url");
            }

            return url!;
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

    public string Content
    {
        get
        {
            if (!IsContent)
            {
                throw new("Not content");
            }

            return content!;
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

    public byte[] Bytes
    {
        get
        {
            if (!IsBytes)
            {
                throw new("Not bytes");
            }

            return bytes!;
        }
    }

    public Input(Stream stream)
    {
        this.stream = stream;
    }

    public Input(byte[] bytes)
    {
        this.bytes = bytes;
    }

    public bool IsStream
    {
        get => stream != null;
    }

    public bool IsContent
    {
        get => content != null;
    }

    public bool IsUrl
    {
        get => url != null;
    }

    public bool IsFile
    {
        get => file != null;
    }

    public bool IsBytes
    {
        get => bytes != null;
    }

    public static implicit operator Input(string value) => new(value);
    public static implicit operator Input(Stream stream) => new(stream);
    public static implicit operator Input(byte[] bytes) => new(bytes);
}