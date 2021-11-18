using CliWrap;

namespace PandocNet;

public class PandocEngine
{
    public async Task Convert(InputOptions input, OutputOptions output)
    {
        var command = Cli.Wrap("pandoc.exe")
            .WithArguments($"--from {input.Format} --to {output.Format}");
        try
        {
            await (input.Stream | command | output.Stream)
                .ExecuteAsync();
        }
        finally
        {
            input.Dispose();
            output.Dispose();
        }
    }
}