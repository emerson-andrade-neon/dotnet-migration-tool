namespace DotNetMigrationTooll.Actions;
internal class UpdateYamel() : IAction
{
    private const string ExtraEnvs = @"extraEnvs:
  - name: OTEL_SERVICE_NAME
    value: ""$DOMAIN.$APP_NAME-$ENV""";

    private const string PodAnnotations = @"podAnnotations:
  dynatrace.com/inject: ""false""";


    public async Task<ActionResult> Execute(Context context)
    {
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
}
