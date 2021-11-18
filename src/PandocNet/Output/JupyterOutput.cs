namespace PandocNet;

public class JupyterOutput :
    OutputOptions
{
    public JupyterOutput(Stream stream) :
        base(stream)
    {
    }

    public JupyterOutput(string file) :
        base(file)
    {
    }

    public override string Format => "ipynb";
}