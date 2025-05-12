//using DotNetMigrationTooll.Actions;
//using DotNetMigrationTooll.Executions;
//using System.Text;

//var actions = ActionConfig.GetStandardActions();

//var batchExecutor = new BatchExecutor(actions, new Observer());

//batchExecutor.AddRepository("reward-platform.core");

//await batchExecutor.Execute(ExecutionOptions.All);


//public class Observer : IExecutorObserver
//{
//    public void AfterExecution(Context context, Execution execution)
//    {
//        Console.WriteLine($"{execution.Action.GetType().Name}: Status: {execution.Status}");
//    }

//    public void BeforeExecution(Context context, Execution execution)
//    {
//        Console.WriteLine($"{execution.Action.GetType().Name}: Executing ...");
//    }

//    public void Begin(Context context, Executor executor)
//    {
//        Console.WriteLine("====================================");
//        Console.WriteLine(context);
//    }

//    public void End(Context context, Executor executor)
//    {
//        var sb = new StringBuilder();

//        sb.AppendLine($"====================================");
//        sb.AppendLine($"Current Action: {executor.CurrentAction.Name}");
//        sb.AppendLine($"Current Status: {executor.CurrentStatus.ToString()}");

//        sb.AppendLine($"====================================");

//        Console.WriteLine(sb.ToString());

//    }
//}


namespace DotNetMigrationTooll.Win;

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        Application.Run(new WorkflowForm());
    }
}