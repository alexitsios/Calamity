using System;

[AttributeUsage(AttributeTargets.Field)]
public class PriorityAttribute : Attribute
{
	private int _priority;

	public PriorityAttribute(int priority)
	{
		_priority = priority;
	}
}
