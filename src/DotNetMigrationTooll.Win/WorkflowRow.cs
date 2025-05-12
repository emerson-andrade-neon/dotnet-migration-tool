using DotNetMigrationTooll.Workflows;

namespace DotNetMigrationTooll.Win;

public class WorkflowRow(Workflow Executor)
{
    public string Repository => Executor.Context.RepoName;
    public string CurrentAction => Executor.CurrentAction.Name;
    public string CurrentStatus => Executor.CurrentStatus.ToString();

    public Workflow Executor { get; } = Executor;
}


