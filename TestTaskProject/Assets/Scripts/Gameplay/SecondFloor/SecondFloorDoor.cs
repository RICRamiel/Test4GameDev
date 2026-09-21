using UnityEngine;
using Zenject;

namespace Gameplay.SecondFloor
{
    public class SecondFloorDoor : SceneTransitionDoor
    {
        [Inject] private GameState _gameState;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player"))
            {
                return;
            }

            if (!_gameState.IsSecondFloorReturnRequired)
            {
                _gameState.RequireReturnToFirstFloor();

                Debug.Log("You forgot something. Return to the first floor.");

                return;
            }

            if (!_gameState.HasSecondFloorKey)
            {
                Debug.Log("The door is locked. You need a key.");

                return;
            }

            Transition();
        }
    }
}