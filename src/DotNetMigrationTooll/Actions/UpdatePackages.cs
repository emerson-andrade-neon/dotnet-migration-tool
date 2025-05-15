using System.Diagnostics;

namespace DotNetMigrationTooll.Actions;
internal class UpdatePackages : IAction
{
    public async Task<ActionResult> Execute(Context context)
    {
        await ExecuteProcess("dotnet tool install --global dotnet-outdated-tool");

        return await ExecuteProcess($"dotnet outdated --upgrade {context.LocalPath}");
    }

    private static async Task<ActionResult> ExecuteProcess(string command)
    {
        var processStartInfo = new ProcessStartInfo("dotnet", command)
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
