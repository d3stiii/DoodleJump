using System.Collections.Generic;
using System.Linq;
using CodeBase.StaticData.World;
using UnityEngine;

namespace CodeBase.Platforms
{
    public class PlatformSpawner : MonoBehaviour
    {
        [SerializeField] private PlatformSpawnerConfig _config;

        private readonly Queue<Platform> _pool = new();
        private Transform _observableTarget;
        private UnityEngine.Camera _camera;

        private void Update()
        {
            var firstPlatform = _pool.Peek();
            if (IsCloseToPlatform(firstPlatform))
                return;

            ReplacePlatform(firstPlatform);
        }

        public void Construct(Transform observableTarget)
        {
            _observableTarget = observableTarget;
            _camera = UnityEngine.Camera.main;
            for (var i = 0; i < _config.PoolSize; i++)
                SpawnPlatform();
        }

        private bool IsCloseToPlatform(Platform firstPlatform) =>
            _observableTarget.position.y - firstPlatform.transform.position.y < _config.MaxDistanceFromTarget;

        private void SpawnPlatform()
        {
            var spawnPosition = CalculateSpawnPosition();

            var platform = Instantiate(_config.Platform, spawnPosition, Quaternion.identity, transform);
            _pool.Enqueue(platform);
        }

        private void ReplacePlatform(Platform firstPlatform)
        {
            _pool.Dequeue();
            firstPlatform.transform.position = CalculateSpawnPosition();
            _pool.Enqueue(firstPlatform);
        }

        private Vector2 CalculateSpawnPosition()
        {
            var spawnPosition = new Vector2();
            if (_pool.Count == 0) return spawnPosition;

            var lastPlatform = _pool.Last();
            spawnPosition.y = lastPlatform.transform.position.y + Random.Range(_config.RandomYMin, _config.RandomYMax);
            spawnPosition.x =
                _camera
                    .ScreenToViewportPoint(
                        new Vector3(
                            Random.Range(-Screen.width * _config.RandomXMultiplier,
                                Screen.width * _config.RandomXMultiplier), 0))
                    .x;

            return spawnPosition;
        }
    }
}