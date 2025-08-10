namespace Pandoc;

public class Options
{
    /// <summary>
    /// Specify the user data directory to search for pandoc data files. If this option is not specified, the default user data directory will be used.
    /// https://pandoc.org/MANUAL.html#option--data-dir
    /// </summary>
    public string? DataDirectory { get; set; }

    /// <summary>
    /// Specify a set of default option settings. FILE is a YAML file whose fields correspond to command-line option settings.
    /// https://pandoc.org/MANUAL.html#option--defaults
    /// </summary>
    public string? DefaultsFile { get; set; }

    /// <summary>
    /// Write log messages in machine-readable JSON format to FILE. All messages above DEBUG level will be written, regardless of verbosity settings.
    /// https://pandoc.org/MANUAL.html#option--log
    /// </summary>
    public string? LogFile { get; set; }

    /// <summary>
    /// Custom arguments to be passed to Pandoc.
    /// </summary>
    public string[]? CustomArguments { get; set; }

    public static IEnumerable<string> GetArguments(Options? options)
    {
        if (options == null)
        {
            yield break;
        }

        if (options.DataDirectory != null)
        {
            yield return $"--data-dir={options.DataDirectory}";
        }

        if (options.DefaultsFile != null)
        {
            yield return $"--defaults={options.DefaultsFile}";
        }

        if (options.LogFile != null)
        {
            yield return $"--log={options.LogFile}";
        }

        if (options.CustomArguments != null)
        {
            foreach (var arg in options.CustomArguments)
            {
                yield return arg;
            }
        }
    }
}
