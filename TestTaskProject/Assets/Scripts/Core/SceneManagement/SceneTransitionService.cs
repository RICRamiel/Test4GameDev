using UnityEngine.SceneManagement;
using static EventsProvider;

namespace Core.SceneManagement
{
    public class SceneTransitionService
    {
        private readonly EventManager _eventManager;

        public SceneTransitionService(EventManager eventManager)
        {
            _eventManager = eventManager;
            _eventManager.Subscribe<SceneTransitionEvent>(OnSceneTransition);
        }

        public void OnSceneTransition(SceneTransitionEvent evt)
        {
            SceneManager.LoadScene(evt.SceneId);
        }
    }
}