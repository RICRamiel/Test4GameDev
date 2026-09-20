using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class SceneTransitionDoor : MonoBehaviour
    {
        [SerializeField] private string _targetScene;

        [Inject] private EventManager _eventManager;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player"))
            {
                return;
            }

            _eventManager.Publish(
                new EventsProvider.SceneTransitionEvent(_targetScene)
            );
        }
    }
}