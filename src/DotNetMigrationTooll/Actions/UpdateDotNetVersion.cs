using System.Text.RegularExpressions;

namespace DotNetMigrationTooll.Actions;
internal class UpdateDotNetVersion() : IAction
{

    public async Task<ActionResult> Execute(Context context)
    {
        string pattern = @"<TargetFramework>.*?</TargetFramework>"; // Usa .*? para capturar o conteúdo de forma não gananciosa
        var newTargeFramework = $"<TargetFramework>{AppEnvironment.NewDotNetVerson}</TargetFramework>";

        var projectFiles = System.IO.Directory.GetFiles(context.LocalPath, "*.csproj", SearchOption.AllDirectories);
        
        foreach (var projectFile in projectFiles)
        {
            var text = await File.ReadAllTextAsync(projectFile);
            string newText = Regex.Replace(text, pattern, newTargeFramework);
            await File.WriteAllTextAsync(projectFile, newText);
        }
        return new ActionResult(0, string.Empty);
        //< TargetFramework > net6.0 </ TargetFramework >

    }
}
