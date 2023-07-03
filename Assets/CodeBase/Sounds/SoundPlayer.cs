using UnityEngine;

namespace CodeBase.Sounds
{
    public class SoundPlayer : MonoBehaviour
    {
        [SerializeField] private AudioSource _effectsSource;

        public void PlaySound(AudioClip sound) => 
            _effectsSource.PlayOneShot(sound);
    }
}