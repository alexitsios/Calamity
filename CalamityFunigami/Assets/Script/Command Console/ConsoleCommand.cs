using System;
public class ConsoleCommand<T1> : ConsoleCommandBase
{
    public Type CommandType => typeof(T1);

    private Action<T1> command;

    public ConsoleCommand(string id, string description, string format, Action<T1> command) : base(id, description, format)
    {
        this.command = command;
    }

    public override void Invoke(string[] args)
    {
        if(args.Length == 1)
        {
			command.Invoke(default);

            return;
		}

		var value = (T1) Convert.ChangeType(args[1], typeof(T1));

        command.Invoke(value);
    }
}