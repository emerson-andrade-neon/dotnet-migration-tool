using System.Diagnostics;

namespace DotNetMigrationTooll.Actions;
internal class Compile : IAction
{
    public async Task<ActionResult> Execute(Context context)
    {
        var processStartInfo = new ProcessStartInfo("dotnet", $"build \"{context.LocalPath}\"")
        {
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        using (var process = new Process { StartInfo = processStartInfo })
        {
            process.Start();
            return await ActionResult.CreateByProcessResult(process);
        }
    }
}
