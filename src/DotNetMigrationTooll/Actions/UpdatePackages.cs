using System.Diagnostics;

namespace DotNetMigrationTooll.Actions;
internal class UpdatePackages : IAction
{
    public async Task<ActionResult> Execute(Context context)
    {
        await ExecuteProcess("dotnet", "dotnet tool install --global dotnet-outdated-tool");

        return await ExecuteProcess("dotnet", $"dotnet outdated --upgrade {context.LocalPath}");
    }

    private static async Task<ActionResult> ExecuteProcess(string fileName, string command)
    {
        var processStartInfo = new ProcessStartInfo(fileName, command)
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
