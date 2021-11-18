using CliWrap;

namespace PandocNet;

public class PandocEngine
{
    public async Task Convert(InputOptions input, OutputOptions output)
    {
        var command = Cli.Wrap("pandoc.exe")

            .WithArguments($"--from {input.Format} ")
            .WithArguments(input.GetArguments())

            // Force binary to stdout https://pandoc.org/MANUAL.html#option--output
            .WithArguments("-o -")

            .WithArguments($"--to {output.Format}")
            .WithArguments(output.GetArguments());
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