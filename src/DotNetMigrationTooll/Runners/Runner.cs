using DotNetMigrationTooll.Actions;
using DotNetMigrationTooll.Workflows;

namespace DotNetMigrationTooll.Runners;
public class Runner(IEnumerable<IAction> actions, IWorkflowObserver observer)
{
    private readonly List<Workflow> _workflows = [];
    public IEnumerable<Workflow> Workflows
    {
        get => _workflows;
        init => _workflows = value.ToList();
    }

    public void AddRepository(string repositoryName)
    {
        if (!_workflows.Any(e => e.ExistRepository(repositoryName)))
        {
            var context = new Context(repositoryName);
            var executions = actions.Select(a => new Activity(a));
            _workflows.Add(new Workflow(context, executions, observer));
        }
    }

    public void AddRepositories(IEnumerable<string> repositoryNames)
    {
        foreach (var repositoryName in repositoryNames)
        {
            AddRepository(repositoryName);
        }
    }

    public Task Run(RunnerOptions options) => RunSelection(options, _workflows);

    public async Task RunSelection(RunnerOptions options, IEnumerable<Workflow> workflows)
    {
        foreach (var executor in workflows)
        {
            await executor.Execute(options);
        }
    }

    public void Remove(List<Workflow> workflow)
    {
        _workflows.RemoveAll(e => workflow.IndexOf(e) >= 0);
    }
}
