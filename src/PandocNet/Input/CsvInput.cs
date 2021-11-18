namespace PandocNet;

public class CsvInput :
    InputOptions
{
    public CsvInput(Stream stream) :
        base(stream)
    {
    }

    public CsvInput(string file) :
        base(file)
    {
    }

    public override string Format => "csv";
}