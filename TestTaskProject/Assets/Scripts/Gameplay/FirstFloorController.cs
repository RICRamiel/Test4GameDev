using System.Collections.Generic;
using UnityEngine;
using Zenject;
using static EventsProvider;

namespace Gameplay
{
    //Суть 
    public class FirstFloorController
    {
        private readonly HashSet<string> _requiredCollectibles = new();
        private readonly HashSet<string> _collectedCollectibles = new();

        private readonly GameState _gameState;
        private readonly EventManager _eventManager;
        private readonly FirstFloorSetup _setup;
        private readonly DiContainer _container;

        public FirstFloorController(
            GameState gameState,
            EventManager eventManager,
            FirstFloorSetup setup,
            DiContainer container)
        {
            _gameState = gameState;
            _eventManager = eventManager;
            _setup = setup;
            _container = container;

            _eventManager.Subscribe<CollectibleCollectedEvent>(OnCollectibleCollected);

            if (!_gameState.IsFirstFloorCompleted)
            {
                SpawnCollectibles();
            }
        }
        
        //Обработчик события подбора предмета для прохождения
        private void OnCollectibleCollected(CollectibleCollectedEvent evt)
        {
            if (!_requiredCollectibles.Contains(evt.CollectibleId))
            {
                return;
            }

            if (!_collectedCollectibles.Add(evt.CollectibleId))
            {
                return;
            }

            Debug.Log(
                $"Collected: {_collectedCollectibles.Count}/{_requiredCollectibles.Count}"
            );

            if (_collectedCollectibles.Count >= _requiredCollectibles.Count)
            {
                _gameState.CompleteFirstFloor();
                Debug.Log("First floor completed!");
            }
        }

        private void SpawnCollectibles()
        {
            for (int i = 0; i < _setup.SpawnPoints.Length; i++)
            {
                Transform spawnPoint = _setup.SpawnPoints[i];
                Collectible collectible =
                    _container.InstantiatePrefabForComponent<Collectible>(
                        _setup.CollectiblePrefab.gameObject,
                        spawnPoint);
                string collectibleId = $"item_{i}";
                collectible.SetId(collectibleId);
                collectible.transform.SetPositionAndRotation(spawnPoint.position, spawnPoint.rotation);
                _requiredCollectibles.Add(collectibleId);
            }
        }

        public void Dispose()
        {
            _eventManager.Unsubscribe<CollectibleCollectedEvent>(OnCollectibleCollected);
        }
    }
}