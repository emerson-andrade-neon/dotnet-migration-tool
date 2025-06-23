using DotNetMigrationTooll.Actions;

namespace DotNetMigrationTooll;
public static class AppEnvironment
{
    private static readonly IAction[] StandardActions = new IAction[]
    {
        new GitClone(),
        new UpdateDotNetVersion(),
        new UpdateDockerFile(),
        new RemoveMediaTrLib(),
        new MonitoringConfig(),
        new UpdatePackages(),
        new Compile(),
        new GitCheckout(),
        new GitCommit(),
        new GitPush()
    };
    static AppEnvironment()
    {
        RepoPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "dotnet-migration-tool");

        if (!Directory.Exists(RepoPath))
        {
            Directory.CreateDirectory(RepoPath);
        }
    }
    public static IEnumerable<IAction> GetStandardActions() => StandardActions;

    public static readonly string NewDotNetVerson = "net9.0";

    public static readonly string RepoPath;

    public static string SavedPath => Path.Combine(RepoPath, "saved.json");

    public static string WorkBranch => $"feature-migration-{NewDotNetVerson}";

    public static string WorkCommitMessage => $"chore: migration to {NewDotNetVerson} version";
}
