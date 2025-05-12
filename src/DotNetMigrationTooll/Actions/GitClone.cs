using System.Diagnostics;

namespace DotNetMigrationTooll.Actions;
class GitClone : IAction
{
    public async Task<ActionResult> Execute(Context context)
    {
        if (Directory.Exists(context.LocalPath))
        {
            return new(0, $"The repository is already cloned. {context.RepoName}");
        }

        var processStartInfo = new ProcessStartInfo("git", $"clone {context.Url} {context.LocalPath}")
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
