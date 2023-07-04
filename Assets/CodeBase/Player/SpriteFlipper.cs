using CodeBase.Services.Input;
using UnityEngine;

namespace CodeBase.Player
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class SpriteFlipper : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        private IInputService _inputService;

        private void Update() =>
            Flip();

        private void Flip() =>
            _spriteRenderer.flipX = _inputService.MovementAxis.x switch
            {
                < 0 => false,
                > 0 => true,
                _ => _spriteRenderer.flipX
            };

        public void Construct(IInputService inputService) =>
            _inputService = inputService;
    }
}