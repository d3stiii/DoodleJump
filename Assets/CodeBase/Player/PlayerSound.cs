using CodeBase.Sounds;
using UnityEngine;

namespace CodeBase.Player
{
    [RequireComponent(typeof(PlayerMovement))]
    public class PlayerSound : MonoBehaviour
    {
        [SerializeField] private PlayerMovement _playerMovement;
        [SerializeField] private AudioClip _jumpSound;
        private SoundPlayer _soundPlayer;

        private void Awake() => 
            _playerMovement.OnJump += PlayJumpSound;

        public void Construct(SoundPlayer soundPlayer) => 
            _soundPlayer = soundPlayer;

        private void PlayJumpSound() => 
            _soundPlayer.PlaySound(_jumpSound);
    }
}