using System.Diagnostics;

namespace DotNetMigrationTooll.Actions;
class GitCommit : IAction
{
    private const int BranchAlreadyExistsCode = 128;
    public async Task<ActionResult> Execute(Context context)
    {

        var command = $"commit -am '{AppEnvironment.WorkCommitMessage}' --no-verify";
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
            return await ActionResult.CreateByProcessResult(process, BranchAlreadyExistsCode);
        }
    }
}
