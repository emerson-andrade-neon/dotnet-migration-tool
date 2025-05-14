using System.Diagnostics;

namespace DotNetMigrationTooll.Actions;
class GitCommit : IAction
{
    public async Task<ActionResult> Execute(Context context)
    {
        var command = @$"commit -am ""{AppEnvironment.WorkCommitMessage}"" --no-verify";

        var gitStatus = await ExecuteCommand(context, "status --porcelain");

        if (!string.IsNullOrEmpty(gitStatus.Message))
        {
            await ExecuteCommand(context, "add .");
            return await ExecuteCommand(context, command);
        }
        else
        {
            return new(0, "No changes to commit");
        }
    }

    private static async Task<ActionResult> ExecuteCommand(Context context, string command)
    {
        var processStartInfo = new ProcessStartInfo("git", command)
        {
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true,
            WorkingDirectory = context.LocalPath
        };

        using (var process = new Process { StartInfo = processStartInfo })
        {
            process.Start();
            return await ActionResult.CreateByProcessResult(process);
        }
    }
}
