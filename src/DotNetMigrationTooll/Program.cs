//// See https://aka.ms/new-console-template for more information
//using DotNetMigrationTooll.Actions;
//using DotNetMigrationTooll.Executions;



//var actions = new IAction[]
//{
//    new GitClone(),
//    new UpdateDotNetVersion("net8.0"),
//    new UpdatePackages(),
//    new Compile()
//};


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

//    public void Begin(Context context, IEnumerable<Execution> executions)
//    {
//        Console.WriteLine("====================================");
//        Console.WriteLine(context);
//    }

//    public void End(Context context, IEnumerable<Execution> executions)
//    {
//        Console.WriteLine("====================================");
//    }
//}