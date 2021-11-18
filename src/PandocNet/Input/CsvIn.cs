namespace PandocNet;

public class CsvIn :
    InOptions
{
    public CsvIn(Stream stream) :
        base(stream)
    {
    }

    public CsvIn(string file) :
        base(file)
    {
    }

    public override string Format => "csv";
}