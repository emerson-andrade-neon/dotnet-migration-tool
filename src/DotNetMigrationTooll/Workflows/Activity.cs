using DotNetMigrationTooll.Actions;
using DotNetMigrationTooll.Runners;

namespace DotNetMigrationTooll.Workflows;

public class Activity(IAction action)
{
    public IAction Action { get; } = action;
    public ActivityStatus Status { get; set; } = ActivityStatus.Pending;
    public string Message { get; set; } = string.Empty;
    public bool CanExecute(RunnerOptions options)
    {
        if (options.CheckIgnoredAction(Action))
        {
            return false;
        }
        if (options.Condition == RunCondition.All)
        {
            return true;
        }
        return Status == ActivityStatus.Pending || Status == ActivityStatus.Fail || Status == ActivityStatus.Skiped;
    }
    public bool Continue => Status == ActivityStatus.Success;
    public async Task Execute(Context context)
    {
        var result = await Action.Execute(context);
        Status = result.IsSuccess ? ActivityStatus.Success : ActivityStatus.Fail;
        Message = result.Message;
    }

    private void ClearStatus(ActivityStatus clearedStatus)
    {
        Status = clearedStatus;
        Message = string.Empty;
    }
    public void Reset() => ClearStatus(ActivityStatus.Pending);

    internal void Skip() => ClearStatus(ActivityStatus.Skiped);
}
