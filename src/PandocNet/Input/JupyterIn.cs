namespace PandocNet;

public class JupyterIn :
    InOptions
{
    public JupyterIn(Stream stream) :
        base(stream)
    {
    }

    public JupyterIn(string file) :
        base(file)
    {
    }

    public override string Format => "ipynb";
}