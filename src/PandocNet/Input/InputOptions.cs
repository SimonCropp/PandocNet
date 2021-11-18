namespace PandocNet;

public abstract class InputOptions :
    IDisposable
{
    bool isOwned;
    public Stream Stream { get; }
    //https://pandoc.org/MANUAL.html#reader-options
    public int ShiftHeadingLevelBy { get; set; }
    public abstract string Format { get; }

    public virtual IEnumerable<string> GetArguments()
    {
        if(ShiftHeadingLevelBy!= 0)
        {
            yield return $"--shift-heading-level-by={ShiftHeadingLevelBy}";
        }
    }
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