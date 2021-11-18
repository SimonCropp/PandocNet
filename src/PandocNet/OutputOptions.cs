namespace PandocNet;

public abstract class OutputOptions
{
    bool isOwned;
    public Stream Stream { get; }
    public abstract string Format { get; }

    public OutputOptions(Stream stream)
    {
        Stream = stream;
    }

    public OutputOptions(string file)
    {
        Stream = File.OpenWrite(file);
        isOwned = true;
    }

    public void Dispose()
    {
        if (isOwned)
        {
            Stream.Dispose();
        }
    }
}