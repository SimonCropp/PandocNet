namespace PandocNet;

public abstract class InputOptions :
    IDisposable
{
    bool isOwned;
    public Stream Stream { get; }
    public abstract string Format { get; }

    public InputOptions(Stream stream)
    {
        Stream = stream;
    }

    public InputOptions(string file)
    {
        Stream = File.OpenRead(file);
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