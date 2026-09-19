using UnityEngine;

namespace Gameplay
{
    public class FirstFloorSetup : MonoBehaviour
    {
        [SerializeField]
        private Collectible _collectiblePrefab;

        [SerializeField]
        private Transform[] _spawnPoints;

        [SerializeField]
        private Collectible _keyPrefab;

        [SerializeField]
        private Transform _keySpawnPoint;

        public Collectible CollectiblePrefab => _collectiblePrefab;

        public Transform[] SpawnPoints => _spawnPoints;

        public Collectible KeyPrefab => _keyPrefab;

        public Transform KeySpawnPoint => _keySpawnPoint;
    }
}