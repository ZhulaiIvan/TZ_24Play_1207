using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Environment
{
    public class WorldGeneration : MonoBehaviour
    {
        [SerializeField] private Platform[] _prefabs;
        [SerializeField] private Platform _lastPlatform;

        [SerializeField, Header("Platform spawn offset")]
        private Vector3 _spawnOffset;

        private List<Platform> _platforms = new();

        private void Start()
        {
            _platforms.AddRange(FindObjectsOfType<Platform>());
            _platforms.ForEach(p => p.TriggerZone.OnTriggered += SpawnPlatform);
        }

        private void SpawnPlatform()
        {
            Platform platform = Instantiate(_prefabs[Random.Range(0, _prefabs.Length)], transform);

            platform.transform.position = new Vector3(_spawnOffset.x, _spawnOffset.y, _spawnOffset.z);

            Vector3 platformScale = platform.transform.localScale;

            platform.SetTargetPosition(new Vector3(
                _lastPlatform.MaxPosition.x - platformScale.x / 2,
                _lastPlatform.MaxPosition.y - platformScale.y / 2,
                _lastPlatform.MaxPosition.z + platformScale.z / 2));

            _platforms.Add(platform);

            _lastPlatform = platform;
            _lastPlatform.TriggerZone.OnTriggered += SpawnPlatform;

            RemovePlatform();
        }

        private void RemovePlatform()
        {
            if (_platforms.Count <= 7) return;

            _platforms[0].TriggerZone.OnTriggered -= SpawnPlatform;
            Destroy(_platforms[0].gameObject);
            _platforms.RemoveAt(0);
        }
    }
}