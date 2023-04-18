using UnityEngine;

namespace Calamity.Audio
{
	public abstract class AudioEvent : ScriptableObject
	{
		public abstract void Play(AudioSource source);

		public bool LimitOneSimultaneous;
	}
}