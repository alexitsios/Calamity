using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerStates : MonoBehaviour
{
	#region Public Variables
	public static PlayerStates Instance { get; private set; }
	#endregion

	#region Private Variables
	private PlayerState playerState;
	private List<Subscriber> subscribers;
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
	///		Sets the current player state to a new one, and notifies all subscribers of that state
	/// </summary>
	/// <param name="state">The new state</param>
	public void SetCurrentPlayerState(PlayerState state)
	{
		playerState = state;

		subscribers.Where(s => s.State == state).ToList().ForEach(s => s.Method.Invoke());
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
