using UnityEngine;
using Calamity.AssetOrganization;

namespace Calamity.Audio
{
    [CreateAssetMenu(menuName = AssetMenuSortOrders.AudioPath + "Sound Effects Player Reference", fileName = "SoundEffectsPlayerReference", order = AssetMenuSortOrders.AudioOrder + 3)]
    public class SoundEffectsPlayerReference : ScriptableObject
    {
        private SoundEffectsPlayer _soundEffectsplayer;

        public SoundEffectsPlayer Player
        {
            get
            {
                if (_soundEffectsplayer == null)
                {
                    GameObject mainSoundPlayer = GameObject.FindGameObjectWithTag("MainSoundPlayer");
                    _soundEffectsplayer = mainSoundPlayer.GetComponent<SoundEffectsPlayer>();
                }

                return _soundEffectsplayer;
            }
        }

        public void PlaySound(AudioEvent _sound)
        {
            Player?.PlaySound(_sound);
        }
    }
}
