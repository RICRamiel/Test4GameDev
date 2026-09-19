using UnityEngine;

namespace Gameplay
{
    public class FirstFloorSetup : MonoBehaviour
    {
        [SerializeField]
        private Collectible _collectiblePrefab;

        [SerializeField]
        private Transform[] _spawnPoints;

        public Collectible CollectiblePrefab => _collectiblePrefab;

        public Transform[] SpawnPoints => _spawnPoints;
    }
}