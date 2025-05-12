using DotNetMigrationTooll.Actions;
using DotNetMigrationTooll.Runners;

namespace DotNetMigrationTooll.Workflows;

public class Workflow(Context context, IEnumerable<Activity> activities, IWorkflowObserver observer)
{
    public Context Context => context;
    public IEnumerable<Activity> Activities { get; } = activities.ToArray();
    public bool ExistRepository(string repositoryName) => string.Equals(context.RepoName, repositoryName, StringComparison.OrdinalIgnoreCase);
    public IAction CurrentAction => GetCurrentActivity().Action;
    public ActivityStatus CurrentStatus => GetCurrentActivity().Status;

    private Activity GetCurrentActivity()
    {
        var firstPending = Activities
            .FirstOrDefault(e => e.Status is (ActivityStatus.Pending or ActivityStatus.Fail));
        return firstPending ?? Activities.Last();
    }

    public async Task Execute(RunnerOptions options)
    {
        observer.Begin(Context, this);
        foreach (var activity in Activities)
        {
            if (activity.CanExecute(options))
            {
                activity.Reset();
                observer.BeforeExecution(Context, activity);
                await activity.Execute(Context);
                observer.AfterExecution(Context, activity);
                if (!activity.Continue)
                {
                    break;
                }
            }
            else
            {
                activity.Skip();
            }
        }

        observer.End(Context, this);
    }
}
