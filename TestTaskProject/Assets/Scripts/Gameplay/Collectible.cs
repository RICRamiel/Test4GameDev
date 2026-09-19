using System;
using UnityEngine;
using Zenject;
using static EventsProvider;

namespace Gameplay
{
    public class Collectible : MonoBehaviour
    {
        [Inject] private EventManager _eventManager;

        private string _collectibleId;

        public void SetId(string collectibleId)
        {
            _collectibleId = collectibleId;
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player"))
            {
                return;
            }

            _eventManager.Publish(new CollectibleCollectedEvent(_collectibleId));
            Destroy(gameObject);
        }
    }
}