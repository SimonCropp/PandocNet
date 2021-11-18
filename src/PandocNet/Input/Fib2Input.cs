namespace PandocNet;

public class Fib2Input :
    InputOptions
{
    public Fib2Input(Stream stream) :
        base(stream)
    {
    }

    public Fib2Input(string file) :
        base(file)
    {
    }

    public override string Format => "fb2";
}