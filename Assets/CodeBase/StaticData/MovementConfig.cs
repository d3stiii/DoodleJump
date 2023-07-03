using UnityEngine;

namespace CodeBase.StaticData
{
    [CreateAssetMenu(menuName = "Player/Movement Config", fileName = "MovementConfig")]
    public class MovementConfig : ScriptableObject
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _jumpForce;

        public float Speed => _speed;
        public float JumpForce => _jumpForce;
    }
}