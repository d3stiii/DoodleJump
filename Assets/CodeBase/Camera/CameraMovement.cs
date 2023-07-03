using UnityEngine;

namespace CodeBase.Camera
{
    public class CameraMovement : MonoBehaviour
    {
        private Transform _target;

        private void LateUpdate()
        {
            if (transform.position.y < _target.position.y)
                transform.position = new Vector3(transform.position.x, _target.position.y, transform.position.z);
        }

        public void Construct(Transform target)
        {
            if (target == transform) return;

            _target = target;
        }
    }
}