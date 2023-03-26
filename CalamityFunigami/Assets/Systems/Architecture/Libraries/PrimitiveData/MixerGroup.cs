using Calamity.AssetOrganization;
using Calamity.Primitives;
using UnityEngine;
using UnityEngine.Audio;

namespace Calamity.Audio
{
    [CreateAssetMenu(menuName = AssetMenuSortOrders.AudioPath + "Mixer Group", fileName = "MixerGroup", order = AssetMenuSortOrders.AudioOrder + 2)]
    public class MixerGroup : ScriptableObject
    {
        public AudioMixerGroup _MixerGroup;

        public void SetVolume(FloatVariable targetVolume)
        {
            float targetFloat = (targetVolume.Value > 0) ? Mathf.Log10(targetVolume.Value) * 20 : -80;
            _MixerGroup.audioMixer.SetFloat(_MixerGroup.name, targetFloat);

        }        
    }
}