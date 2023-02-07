using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
	#region Public Variables
	public static PlayerStateManager Instance { get; private set; }
	#endregion

	#region Private Variables
	private PlayerState playerState;
	private List<PlayerState> pendingStates = new();
	private List<Subscriber> subscribers = new();
	#endregion

	private void Awake()
	{
		if(Instance != null && Instance != this)
		{
			Destroy(this);
		}
		else
		{
			Instance = this;
		}
	}

	public PlayerState GetCurrentPlayerState()
	{
		return playerState;
	}

	/// <summary>
	///		Adds a new state to the list of pending states. If that state has a higher priority, the current state will be changed and all subscribers will be notified
	/// </summary>
	/// <param name="state">The new state</param>
	public void TrySetCurrentPlayerState(PlayerState state)
	{
		if(pendingStates.Contains(state))
		{
			return;
		}

		pendingStates.Add(state);

		var maxPendingState = pendingStates.Max(p => p);

		if(maxPendingState > playerState)
		{
			SetPlayerState(maxPendingState);
		}
	}

	/// <summary>
	///		Removes a state from the pending list. If no pending state remains, the player enters the Idle state
	/// </summary>
	/// <param name="state"></param>
	public void RemovePendingState(PlayerState state)
	{
		if(!pendingStates.Contains(state))
		{
			return;
		}

		pendingStates.Remove(state);

		if(pendingStates.Count == 0)
		{
			SetPlayerState(PlayerState.Idle);
		}
	}

	private void SetPlayerState(PlayerState state)
	{
		playerState = state;
		subscribers.Where(s => s.State == playerState).ToList().ForEach(s => s.Method.Invoke());
	}

	/// <summary>
	///		Adds a new subscriber to the list
	/// </summary>
	/// <param name="state">The player state to be notified about</param>
	/// <param name="method">The method to invoke when the player enters that state</param>
	public void AddSubscriber(PlayerState state, Action method)
	{
		subscribers.Add(new Subscriber()
		{
			State = state,
			Method = method
		});
	}
}
