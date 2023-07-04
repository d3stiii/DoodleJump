using CodeBase.Platforms;
using UnityEngine;

namespace CodeBase.StaticData
{
    [CreateAssetMenu(menuName = "World/Platform Spawner Config", fileName = "Platform Spawner Config")]
    public class PlatformSpawnerConfig : ScriptableObject
    {
        [SerializeField] private Platform _platform;
        [SerializeField] private int _poolSize;
        [SerializeField] private float _maxDistanceFromTarget;
        [SerializeField] private float _randomYMin;
        [SerializeField] private float _randomYMax;
        [SerializeField] private float _randomXMultiplier;

        public Platform Platform => _platform;
        public int PoolSize => _poolSize;
        public float MaxDistanceFromTarget => _maxDistanceFromTarget;
        public float RandomYMin => _randomYMin;
        public float RandomYMax => _randomYMax;
        public float RandomXMultiplier => _randomXMultiplier;
    }
}