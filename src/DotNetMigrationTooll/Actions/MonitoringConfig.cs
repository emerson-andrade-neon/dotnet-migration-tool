namespace DotNetMigrationTooll.Actions;
internal class MonitoringConfig() : IAction
{
    private const string ExtraEnvs = @"extraEnvs:
  - name: OTEL_SERVICE_NAME
    value: ""$DOMAIN.$APP_NAME-$ENV""";

    private const string PodAnnotations = @"podAnnotations:
  dynatrace.com/inject: ""false""";

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

        var yamelFiles = System.IO.Directory.GetFiles(context.LocalPath, "values.yaml", SearchOption.AllDirectories);

        var language = @"    LANGUAGE: ""$LANGUAGE""";

        foreach (var yamelFile in yamelFiles)
        {
            var text = (await File.ReadAllTextAsync(yamelFile)).TrimEnd();
            var newText = text;
            if (!text.Contains(language))
            {
                var firstDataLineIndex = text.IndexOf("    ");
                newText = text.Insert(firstDataLineIndex, $"{language}{Environment.NewLine}");
            }
            newText = AddToEnd(newText, ExtraEnvs);
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
            text.Contains("<OutputType>Exe</OutputType>", StringComparison.OrdinalIgnoreCase);
    }
}
