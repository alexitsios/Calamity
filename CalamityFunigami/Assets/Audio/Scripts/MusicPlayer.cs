using UnityEngine;

namespace Calamity.Audio
{
    public class MusicPlayer : AudioPlayer
    {
        public AudioEvent GameMusic;

        private AudioSource _source;

        private void Start()
        {
            _source = gameObject.AddComponent<AudioSource>();
            _source.loop = true;
            _source.outputAudioMixerGroup = _MixerGroup._MixerGroup;

            Play();
        }

        public void Play()
        {
            if (_source)
                GameMusic?.Play(_source);
        }

        public void Stop()
        {
            _source.Stop();
        }
    }

}