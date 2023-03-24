using Calamity.AssetOrganization;
using UnityEngine;

namespace Calamity.Audio
{
    [CreateAssetMenu(menuName = AssetMenuSortOrders.AudioPath + "Audio File Container", order = AssetMenuSortOrders.AudioOrder + 1)]
    public class AudioFile : ScriptableObject
    {
        public AudioClip Source;

        [MinMaxRange(0, 1)]
        public RangedFloat ClampVolume;
    }
}