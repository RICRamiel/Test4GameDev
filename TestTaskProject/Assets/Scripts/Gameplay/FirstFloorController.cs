using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using static EventsProvider;

namespace Gameplay
{
    //Суть первого этажа в простом сборе трёх предметов с открытием двери
    public class FirstFloorController : IDisposable
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
            else if (_gameState.IsSecondFloorReturnRequired && !_gameState.HasSecondFloorKey)
            {
                SpawnKey();
            }
        }

        //Обработчик события подбора предмета для прохождения
        private void OnCollectibleCollected(CollectibleCollectedEvent evt)
        {
            if (evt.CollectibleId == "second_floor_key")
            {
                _gameState.CollectSecondFloorKey();

                Debug.Log("Second floor key collected!");

                return;
            }
            
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

        //Спавн основных предметов этажа
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

        //Спавн ключа для головоломки на следующем этаже
        private void SpawnKey()
        {
            Collectible key =
                _container.InstantiatePrefabForComponent<Collectible>(
                    _setup.KeyPrefab.gameObject,
                    _setup.KeySpawnPoint);

            key.SetId("second_floor_key");

            key.transform.SetPositionAndRotation(
                _setup.KeySpawnPoint.position,
                _setup.KeySpawnPoint.rotation);
        }

        public void Dispose()
        {
            Debug.Log("scene disposed");
            _eventManager.Unsubscribe<CollectibleCollectedEvent>(OnCollectibleCollected);
        }
    }
}