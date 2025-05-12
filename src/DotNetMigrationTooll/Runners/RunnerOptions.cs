using DotNetMigrationTooll.Actions;

namespace DotNetMigrationTooll.Runners;
public record RunnerOptions(RunCondition Condition, IEnumerable<IAction> IgnoredActions)
{
    public bool CheckIgnoredAction(IAction action) => IgnoredActions.Any(ia => ia.Name == action.Name);
}
