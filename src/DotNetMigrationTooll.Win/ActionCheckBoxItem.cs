using DotNetMigrationTooll.Actions;

namespace DotNetMigrationTooll.Win;

public class ActionCheckBoxItem(IAction action)
{
    public IAction Action { get; } = action;

    public override string ToString() => Action.Name;
}

