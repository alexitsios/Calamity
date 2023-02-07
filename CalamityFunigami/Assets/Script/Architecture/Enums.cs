using System.ComponentModel;

public enum PlayerState
{
	[Priority(0)] Idle,
	[Priority(1)] Walking,
	[Priority(2)] Running,
	[Priority(3)] Aiming,
	[Priority(4)] Interacting,
	[Priority(99)] Dead
}