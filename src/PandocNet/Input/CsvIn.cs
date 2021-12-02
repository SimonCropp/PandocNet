namespace Pandoc;

/// <summary>
/// https://datatracker.ietf.org/doc/html/rfc4180
/// </summary>
public class CsvIn :
    InOptions
{
    protected override string Format => "csv";
}