using UnityEngine;
using Calamity.AssetOrganization;

namespace Calamity.Audio
{
	[CreateAssetMenu(menuName = AssetMenuSortOrders.AudioPath + "SimpleAudioEvent", fileName = "SimpleAudioEvent", order = AssetMenuSortOrders.PrimitivesOrder + 3)]
	public class SimpleAudioEvent : StaticAudioEvent
	{
		public override void Play(AudioSource source)
		{
			base.Play(source);
		}
	}
}
