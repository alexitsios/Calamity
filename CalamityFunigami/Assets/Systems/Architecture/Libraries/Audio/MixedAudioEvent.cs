using UnityEngine;
using UnityEngine.Audio;
using Calamity.AssetOrganization;

namespace Calamity.Audio
{
	[CreateAssetMenu(menuName = AssetMenuSortOrders.PrimitivesPath + "MixedAudioEvent", fileName = "MixedAudioEvent", order = AssetMenuSortOrders.PrimitivesOrder + 2)]
	public class MixedAudioEvent : StaticAudioEvent
	{
		public AudioMixerGroup MixerGroup;

		public override void Play(AudioSource source)
		{
			source.outputAudioMixerGroup = (MixerGroup != null) ? MixerGroup : source.outputAudioMixerGroup;
			base.Play(source);
		}
	}
}