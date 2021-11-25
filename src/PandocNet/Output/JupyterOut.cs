namespace Pandoc;

/// <summary>
/// https://nbformat.readthedocs.io/en/latest/
/// </summary>
public class JupyterOut :
    OutOptions
{
    public override string Format => "ipynb";

    /// <summary>
    /// Determines how ipynb output cells are treated. all means that all of the data formats included in the original are preserved
    /// https://pandoc.org/MANUAL.html#option--ipynb-output
    /// </summary>
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