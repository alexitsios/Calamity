using UnityEngine;
using Random = UnityEngine.Random;

namespace Calamity.Audio
{
    public abstract class StaticAudioEvent : AudioEvent
    {
        public AudioFile[] AudioFiles;        
        public RangedFloat Volume;

        [MinMaxRange(0, 2)]
        public RangedFloat Pitch;

        private int _lastRandomClipIndex;
        private float _lastRandomPitch;
        private float _lastRandomVolume;

        private AudioFile _cachedFile;

        public override void Play(AudioSource source)
        {
            if (AudioFiles == null || AudioFiles?.Length == 0 || source == null) return;

            source.clip = SelectClip();
            source.volume = SelectVolume();
            source.pitch = SelectPitch();

            source.Play();
        }

        private AudioClip SelectClip()
        {
            int randomIndex = _lastRandomClipIndex;
            while (AudioFiles.Length > 1 && randomIndex == _lastRandomClipIndex)
            {
                randomIndex = Random.Range(0, AudioFiles.Length);
            }
            _lastRandomClipIndex = randomIndex;

            _cachedFile = AudioFiles[randomIndex];

            AudioClip selectedClip = _cachedFile.Source;
            return selectedClip;
        }

        private float SelectPitch()
        {
            float randomValue = _lastRandomPitch;
            while (randomValue == _lastRandomPitch)
            {
                randomValue = Random.Range(Pitch.MinValue, Pitch.MaxValue);

                if (Pitch.MinValue == Pitch.MaxValue)
                    break;
            }
            _lastRandomPitch = randomValue;
            return randomValue;
        }

        private float SelectVolume()
        {
            float randomValue = _lastRandomVolume;
            while (randomValue == _lastRandomVolume)
            {

                randomValue = Random.Range(Volume.MinValue, Volume.MaxValue);
                randomValue = ClampVolume(randomValue, _cachedFile.ClampVolume.MinValue, _cachedFile.ClampVolume.MaxValue);

                if (Volume.MinValue == Volume.MaxValue)
                    break;
            }
            _lastRandomVolume = randomValue;
            return randomValue;
        }

        private float ClampVolume(float volume, float min, float max)
        {
            if (volume < min)
                volume = min;
            else if (volume > max)
                volume = max;

            return volume;
        }
    }
}