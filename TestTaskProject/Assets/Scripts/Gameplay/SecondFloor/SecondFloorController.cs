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

            _eventManager.Publish(new OpenScreenEvent("SecondFloor"));
        }

        public void Dispose()
        {
            Debug.Log("SecondFloorController disposed");
        }
    }
}