using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CodeBase.Platforms
{
    public class PlatformSpawner : MonoBehaviour
    {
        [SerializeField] private Platform _platform;
        [SerializeField] private int _poolSize;

        [Header("Random Position Settings")] [SerializeField]
        private float _yMin;

        [SerializeField] private float _yMax;
        [SerializeField] private float _xMultiplier;

        private readonly Queue<Platform> _pool = new();
        private bool _initialized;
        private Transform _observableTarget;

        private void Update()
        {
            if (!_initialized)
                return;

            var firstPlatform = _pool.Peek();
            if (_observableTarget.position.y - firstPlatform.transform.position.y < 10) return;

            _pool.Dequeue();
            firstPlatform.transform.position = CalculateSpawnPosition();
            _pool.Enqueue(firstPlatform);
        }

        public void Construct(Transform observableTarget)
        {
            _observableTarget = observableTarget;

            for (var i = 0; i < _poolSize; i++) SpawnPlatform();

            _initialized = true;
        }

        private void SpawnPlatform()
        {
            var spawnPosition = CalculateSpawnPosition();

            var platform = Instantiate(_platform, spawnPosition, Quaternion.identity, transform);
            _pool.Enqueue(platform);
        }

        private Vector2 CalculateSpawnPosition()
        {
            var spawnPosition = new Vector2();
            if (_pool.Count == 0) return spawnPosition;

            var lastPlatform = _pool.Last();
            spawnPosition.y = lastPlatform.transform.position.y + Random.Range(_yMin, _yMax);
            spawnPosition.x =
                UnityEngine.Camera.main!
                    .ScreenToViewportPoint(
                        new Vector3(Random.Range(-Screen.width * _xMultiplier, Screen.width * _xMultiplier), 0))
                    .x;

            return spawnPosition;
        }
    }
}