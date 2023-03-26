using UnityEngine;
using Calamity.Audio;
using Calamity.AssetOrganization;

namespace Calamity.CommandSystem
{
    [CreateAssetMenu(menuName = AssetMenuSortOrders.FeedbackCommandsPath + "PlayAudio", fileName = "PlayAudioCommand", order = AssetMenuSortOrders.FeedbackCommandsOrder + 2)]
    public class PlayAudioEventFeedbackCommand : FeedbackCommand
    {
        [SerializeField] private SoundEffectsPlayerReference _soundEffectsPlayer;
        [SerializeField] private AudioEvent _audioEvent;

        public override void Actions()
        {
            _soundEffectsPlayer.PlaySound(_audioEvent);
        }
    }
}