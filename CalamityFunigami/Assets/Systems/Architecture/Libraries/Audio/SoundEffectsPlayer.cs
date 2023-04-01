using System.Collections;
using UnityEngine;

namespace Calamity.Audio
{
    public class SoundEffectsPlayer : AudioPlayer
    {
        public void LoopSound(AudioEvent audioEvent)
        {
            Play(audioEvent, loop: true);
        }

        public void PlaySound(AudioEvent audioEvent)
        {
            Play(audioEvent);
        }

        private void Play(AudioEvent audioEvent, bool loop = false)
        {
            AudioSource source = gameObject.AddComponent<AudioSource>();
            source.outputAudioMixerGroup = _MixerGroup._MixerGroup;
            source.loop = loop;

            audioEvent.Play(source);

            if (!loop)
                StartCoroutine(DestroyAudioSourceRoutine(source));
        }

        private IEnumerator DestroyAudioSourceRoutine(AudioSource source)
        {
            yield return new WaitForSeconds(source.clip.length);
            source.enabled = false;
            //Destroy(source);
        }
    }
}