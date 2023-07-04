using System;
using UnityEngine;

namespace CodeBase.Points
{
    public class LosePoint : MonoBehaviour
    {
        public event Action OnLose;
        private Transform _target;

        private void Update()
        {
            if (!(_target.position.y <= transform.position.y)) return;

            OnLose?.Invoke();
            DeactivatePoint();
        }

        private void DeactivatePoint() =>
            gameObject.SetActive(false);

        public void Construct(Transform target) =>
            _target = target;
    }
}