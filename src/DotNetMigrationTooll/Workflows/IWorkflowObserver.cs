using DotNetMigrationTooll.Actions;

namespace DotNetMigrationTooll.Workflows;
public interface IWorkflowObserver
{
    void Begin(Context context, Workflow workflow);
    void BeforeExecution(Context context, Activity activity);
    void AfterExecution(Context context, Activity activity);
    void End(Context context, Workflow workflow);
}
