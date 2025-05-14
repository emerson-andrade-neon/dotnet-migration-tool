namespace DotNetMigrationTooll.Actions;

public record Context(string RepoName)
{
    public string Url => $"https://github.com/neon/{RepoName}.git";
    public string LocalPath => System.IO.Path.Combine(AppEnvironment.RepoPath, RepoName);
}
