using UnityEngine;
using Zenject;
using static EventsProvider;

namespace Gameplay
{
    public class SceneTransitionDoor : MonoBehaviour
    {
        [SerializeField] private string _targetScene;

        [Inject] private EventManager _eventManager;

        protected void Transition()
        {
            _eventManager.Publish(new SceneTransitionEvent(_targetScene));
        }
    }
}