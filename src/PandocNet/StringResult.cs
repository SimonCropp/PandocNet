namespace Pandoc;

public record StringResult(string Command, string Value)
{
    public override string ToString() =>
        Value;

    public static implicit operator string(StringResult x) => x.Value;
}