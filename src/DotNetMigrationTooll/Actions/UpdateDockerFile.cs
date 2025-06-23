using System.Text.RegularExpressions;

namespace DotNetMigrationTooll.Actions;
internal class UpdateDockerFile() : IAction
{
    private const string DockerFileTemplate = @"FROM ${REGISTRY_URL}/base-images/dotnet/sdk:9.0-alpine AS build
WORKDIR /app
COPY . .
RUN dotnet publish -c Release -o out #projectName#

FROM ${REGISTRY_URL}/base-images/dotnet/aspnet:9.0-alpine AS runtime
WORKDIR /app
COPY --from=build /app/out .

RUN echo ""dotnet #projectName#.dll"" >> entrypoint.sh \
    && chmod a+x entrypoint.sh

RUN addgroup -S appgroup && adduser -S appuser -G appgroup
USER appuser
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

ENTRYPOINT [""sh"", ""entrypoint.sh""]";

    public async Task<ActionResult> Execute(Context context)
    {
        var dockerFiles = System.IO.Directory.GetFiles(context.LocalPath, "Dockerfile", SearchOption.AllDirectories);

        var projectNamePattern = @"(?<=RUN dotnet publish -c Release -o out\s)(\S+\.\S+)";

        foreach (var dockerFile in dockerFiles)
        {
            var text = await File.ReadAllTextAsync(dockerFile);
            var projectNameMatch = Regex.Match(text, projectNamePattern);

            if (!projectNameMatch.Success)
            {
                return new(1, "Não foi possível localizar o nome do projeto no arquivo Dockerfile");
            }

            var newText = Regex.Replace(DockerFileTemplate, "#projectName#", projectNameMatch.Value);

            await File.WriteAllTextAsync(dockerFile, newText);
        }
        return new ActionResult(0, string.Empty);
    }
}
