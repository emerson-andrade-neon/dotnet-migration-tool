namespace DotNetMigrationTooll.Actions;

public record Context(string RepoName)
{
    private const string OutputDir = @$"C:\temp\Repos\";
    public string Url => $"https://github.com/neon/{RepoName}.git";
    public string LocalPath => System.IO.Path.Combine(OutputDir, RepoName);
}
