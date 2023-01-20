using System;
using UnityEngine;

public class Subscriber
{
	public PlayerState State { get; set; }
	public Action Method { get; set; }
}
