using System.Diagnostics;

namespace DotNetMigrationTooll.Actions;
class GitPush : IAction
{
    private const int BranchAlreadyExistsCode = 128;
    public async Task<ActionResult> Execute(Context context)
    {
        var command = $"push --set-upstream origin {AppEnvironment.WorkBranch} --no-verify -f";
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
