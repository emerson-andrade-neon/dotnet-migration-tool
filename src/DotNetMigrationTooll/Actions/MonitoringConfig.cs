namespace DotNetMigrationTooll.Actions;
internal class MonitoringConfig() : IAction
{
    private const string LanguageEnv = @"    LANGUAGE: ""$LANGUAGE""";

    private const string OtelEnv = @"    OTEL_AUTO_INSTRUMENTATION: ""$OTEL_AUTO_INSTRUMENTATION""";

    private const string PodAnnotations = @"podAnnotations:
  dynatrace.com/inject: ""false""";

    private const string NewEnvVariables = @"
    OTEL_AUTO_INSTRUMENTATION=true
    LANGUAGE=dotnet";

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
        await AddLogPackagesInHostProjectAsync(context);
        await AddEnvVariablesAsync(context, "dev.env");
        await AddEnvVariablesAsync(context, "hml.env");
        await AddEnvVariablesAsync(context, "prod.env");

        var yamelFiles = System.IO.Directory.GetFiles(context.LocalPath, "values.yaml", SearchOption.AllDirectories);

        var configDataSection = "config:";
        var dataSectionIndicator = "data:";

        foreach (var yamelFile in yamelFiles)
        {
            var text = (await File.ReadAllTextAsync(yamelFile)).TrimEnd();
            var newText = text;
            var configIndex = newText.IndexOf(configDataSection);
            var dataStartIndex = newText.IndexOf(dataSectionIndicator, configIndex) + dataSectionIndicator.Length;
            if (!text.Contains(LanguageEnv))
            {
                newText = newText.Insert(dataStartIndex, $"{Environment.NewLine}{LanguageEnv}");
            }
            if (!text.Contains(OtelEnv))
            {
                newText = newText.Insert(dataStartIndex, $"{Environment.NewLine}{OtelEnv}");
            }
            newText = AddToEnd(newText, PodAnnotations);
            await File.WriteAllTextAsync(yamelFile, newText);
        }
        return new ActionResult(0, string.Empty);
    }


    private string AddToEnd(string text, string textToAdd)
    {
        return !text.Contains(textToAdd) ?
            $"{text}{Environment.NewLine}{textToAdd}" :
            text;
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
            text.Contains("<Project Sdk=\"Microsoft.NET.Sdk.Worker\">", StringComparison.OrdinalIgnoreCase) ||
            text.Contains("<OutputType>Exe</OutputType>", StringComparison.OrdinalIgnoreCase);
    }

    private async Task AddEnvVariablesAsync(Context context, string fileName)
    {
        var projectFiles = System.IO.Directory.GetFiles(context.LocalPath, fileName, SearchOption.AllDirectories);
        foreach (var projectFile in projectFiles)
        {
            var text = await File.ReadAllTextAsync(projectFile);
            if (!text.Contains("LANGUAGE=dotnet"))
            {
                text = $"{text}{Environment.NewLine}{NewEnvVariables}";

                await File.WriteAllTextAsync(projectFile, text);

            }
        }
    }
}
