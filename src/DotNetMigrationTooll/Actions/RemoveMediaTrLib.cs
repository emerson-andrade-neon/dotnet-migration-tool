namespace DotNetMigrationTooll.Actions;
internal class RemoveMediaTrLib : IAction
{
    public async Task<ActionResult> Execute(Context context)
    {
        string pattern = @"<PackageReference Include=""MediatR.Extensions.Microsoft.DependencyInjection"" Version=";

        var projectFiles = System.IO.Directory.GetFiles(context.LocalPath, "*.csproj", SearchOption.AllDirectories);

        foreach (var projectFile in projectFiles)
        {
            var lines = await File.ReadAllLinesAsync(projectFile);

            var newLines = lines.Where(x => !x.Trim().StartsWith(pattern));

            var newText = string.Join(Environment.NewLine, newLines);

            await File.WriteAllTextAsync(projectFile, newText);
        }
        return new ActionResult(0, string.Empty);
        //< TargetFramework > net6.0 </ TargetFramework >
    }
}
