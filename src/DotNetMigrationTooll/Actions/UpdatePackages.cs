using System.Diagnostics;

namespace DotNetMigrationTooll.Actions;
internal class UpdatePackages : IAction
{
    private const string LogPackages = @"
    <ItemGroup>
        <!--libs for monitoring-->
	    <PackageReference Include=""Microsoft.Extensions.Configuration"" Version=""9.0.5"" />
	    <PackageReference Include=""Microsoft.Extensions.Configuration.Abstractions"" Version=""9.0.5"" />
	    <PackageReference Include=""Microsoft.Extensions.Configuration.Binder"" Version=""9.0.5"" />
	    <PackageReference Include=""Microsoft.Extensions.DependencyInjection"" Version=""9.0.5"" />
	    <PackageReference Include=""Microsoft.Extensions.Logging"" Version=""9.0.5"" />
	    <PackageReference Include=""Microsoft.Extensions.Logging.Abstractions"" Version=""9.0.5"" />
	    <PackageReference Include=""Microsoft.Extensions.Logging.Configuration"" Version=""9.0.5"" />
	    <PackageReference Include=""Microsoft.Extensions.Options"" Version=""9.0.5"" />
	    <PackageReference Include=""Microsoft.Extensions.Options.ConfigurationExtensions"" Version=""9.0.5"" />
	    <PackageReference Include=""System.Diagnostics.DiagnosticSource"" Version=""9.0.5"" />
    </ItemGroup>";

    private const string PropertyGroupTag = "</PropertyGroup>";

    public async Task<ActionResult> Execute(Context context)
    {
        AddLogPackagesInHostProjectAsync(context);


        var processStartInfo = new ProcessStartInfo("dotnet", $"dotnet outdated --upgrade {context.LocalPath}")
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

    private async Task AddLogPackagesInHostProjectAsync(Context context)
    {
        var projectFiles = System.IO.Directory.GetFiles(context.LocalPath, "*.csproj", SearchOption.AllDirectories);
        foreach (var projectFile in projectFiles)
        {
            var text = await File.ReadAllTextAsync(projectFile);
            if (IsHost(text) && !text.Contains("<!--libs for monitoring-->"))
            {
                var propertyGroupIndex = text.IndexOf(PropertyGroupTag) + PropertyGroupTag.Length;

                text = text.Insert(propertyGroupIndex, LogPackages);

                await File.WriteAllTextAsync(projectFile, text);

            }
        }
    }

    private bool IsHost(string text)
    {
        return
            text.Contains("<Project Sdk=\"Microsoft.NET.Sdk.Web\">", StringComparison.OrdinalIgnoreCase) ||
            text.Contains("<OutputType>Exe</OutputType>", StringComparison.OrdinalIgnoreCase);
    }
}
