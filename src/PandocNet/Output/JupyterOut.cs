namespace PandocNet;

public class JupyterOut :
    OutOptions
{
    public JupyterOut(Stream stream) :
        base(stream)
    {
    }

    public JupyterOut(string file) :
        base(file)
    {
    }

    public override string Format => "ipynb";
    //https://pandoc.org/MANUAL.html#options-affecting-specific-writers
    public JupyterCellOutput? CellOutput { get; set; }

    public override IEnumerable<string> GetArguments()
    {
        foreach (var argument in base.GetArguments())
        {
            yield return argument;
        }

        if (CellOutput != null)
        {
            yield return $"--ipynb-output={CellOutput}";
        }
    }
}