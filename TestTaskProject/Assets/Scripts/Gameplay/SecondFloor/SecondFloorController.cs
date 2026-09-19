using System;
using UnityEngine;
using static EventsProvider;

namespace Gameplay.SecondFloor
{
    public class SecondFloorController : IDisposable
    {
        private readonly GameState _gameState;
        private readonly EventManager _eventManager;

        public SecondFloorController(GameState gameState, EventManager eventManager)
        {
            _gameState = gameState;
            _eventManager = eventManager;
        }

        public void InteractWithDoor()
        {
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

            Debug.Log("The door is open. You can continue.");
            _eventManager.Publish(new SceneTransitionEvent("ThirdScene"));
        }

        public void Dispose()
        {
            Debug.Log("SecondFloorController disposed");
        }
    }
}