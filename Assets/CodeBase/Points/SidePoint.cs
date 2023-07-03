using UnityEngine;

namespace CodeBase.Points
{
    public class SidePoint : MonoBehaviour
    {
        [SerializeField] private Transform _oppositeSide;
        [SerializeField] private bool _isRightSide;
        private Transform _target;

        private void Update()
        {
            if (_isRightSide)
            {
                if (_target.position.x > transform.position.x)
                    _target.position = new Vector2(_oppositeSide.position.x, _target.position.y);
            }
            else
            {
                if (_target.position.x < transform.position.x)
                    _target.position = new Vector2(_oppositeSide.position.x, _target.position.y);
            }
        }

        public void Construct(Transform target) => 
            _target = target;
    }
}