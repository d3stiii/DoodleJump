using System;
using CodeBase.Services.Input;
using CodeBase.StaticData.Player;
using UnityEngine;

namespace CodeBase.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private MovementConfig _movementConfig;
        [SerializeField] private Rigidbody2D _rigidbody2D;

        private IInputService _inputService;

        private void FixedUpdate()
        {
            _rigidbody2D.velocity =
                new Vector2(_inputService.MovementAxis.x * _movementConfig.Speed, _rigidbody2D.velocity.y);
        }

        public event Action OnJump;

        public void Construct(IInputService inputService) => 
            _inputService = inputService;

        public void Jump()
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _movementConfig.JumpForce);
            OnJump?.Invoke();
        }

        public void StopMovement()
        {
            _rigidbody2D.velocity = Vector2.zero;
            _rigidbody2D.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }
}