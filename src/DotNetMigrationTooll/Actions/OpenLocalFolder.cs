using System.Diagnostics;

namespace DotNetMigrationTooll.Actions;
public class OpenLocalFolder : IAction
{
    public async Task<ActionResult> Execute(Context context)
    {

        var processStartInfo = new ProcessStartInfo("explorer", context.LocalPath);
        using (var process = new Process { StartInfo = processStartInfo })
        {
            process.Start();
            return await ActionResult.CreateByProcessResult(process);
        }
    }

    public static void Open(Context context) => new OpenLocalFolder().Execute(context).Wait();
}
