namespace Pandoc;

public class JupyterOut :
    OutOptions
{
    public override string Format => "ipynb";
    
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