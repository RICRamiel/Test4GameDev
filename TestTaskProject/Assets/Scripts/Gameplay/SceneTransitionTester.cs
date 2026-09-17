using Zenject;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Gameplay
{
    public class SceneTransitionTester : MonoBehaviour
    {
        [SerializeField]
        private string _targetScene;

        [Inject]
        private EventManager _eventManager;

        private void Update()
        {
            if (Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                Debug.Log("try to publish event");
                _eventManager.Publish(
                    new EventsProvider.SceneTransitionEvent(_targetScene)
                );
            }
        }
    }
}