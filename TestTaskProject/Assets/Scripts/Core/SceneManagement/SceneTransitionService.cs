using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core.SceneManagement
{
    public class SceneTransitionService
    {
        private readonly EventManager _eventManager;

        public SceneTransitionService(EventManager eventManager)
        {
            _eventManager = eventManager;
            _eventManager.Subscribe<EventsProvider.SceneTransitionEvent>(OnSceneTransition);
        }

        public void OnSceneTransition(EventsProvider.SceneTransitionEvent evt)
        {
            Debug.Log("OnSceneTransition");
            SceneManager.LoadScene(evt.SceneId);
        }
    }
}