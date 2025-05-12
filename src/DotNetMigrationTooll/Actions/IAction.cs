namespace DotNetMigrationTooll.Actions;

public interface IAction
{
    Task<ActionResult> Execute(Context context);

    public string Name => this.GetType().Name;

    //public string Type => this.GetType().FullName;
}


