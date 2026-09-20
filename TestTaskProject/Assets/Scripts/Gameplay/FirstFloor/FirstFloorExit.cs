using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Gameplay.FirstFloor
{
    public class FirstFloorExit : SceneTransitionDoor
    {
        [Inject] private GameState _gameState;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player"))
            {
                return;
            }

            if (!_gameState.IsFirstFloorCompleted)
            {
                Debug.Log("You need to collect all items first");
                return;
            }

            Transition();
        }
    }
}