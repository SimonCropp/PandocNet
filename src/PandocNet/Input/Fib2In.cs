namespace PandocNet;

public class Fib2In :
    InOptions
{
    public Fib2In(Stream stream) :
        base(stream)
    {
    }

    public Fib2In(string file) :
        base(file)
    {
    }

    public override string Format => "fb2";
}