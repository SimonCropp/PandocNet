namespace PandocNet;

public class JupyterInput :
    InputOptions
{
    public JupyterInput(Stream stream) :
        base(stream)
    {
    }

    public JupyterInput(string file) :
        base(file)
    {
    }

    public override string Format => "ipynb";
}