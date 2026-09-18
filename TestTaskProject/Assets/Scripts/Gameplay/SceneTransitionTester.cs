using Zenject;
using UnityEngine;
using UnityEngine.InputSystem;
using static EventsProvider;

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
                _eventManager.Publish(
                    new SceneTransitionEvent(_targetScene)
                );
            }
        }
    }
}