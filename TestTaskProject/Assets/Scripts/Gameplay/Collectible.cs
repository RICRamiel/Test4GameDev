using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class Collectible : MonoBehaviour
    {
        [Inject]
        private GameState _gameState;
        
        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player"))
            {
                return;
            }
            _gameState.CollectItem();
            Destroy(gameObject);
        }
        
    }
}