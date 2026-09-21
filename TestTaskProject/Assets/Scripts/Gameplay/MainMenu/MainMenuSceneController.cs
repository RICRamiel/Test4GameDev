using UnityEngine;
using Zenject;
using static EventsProvider;

public class MainMenuSceneController : MonoBehaviour
{
    [Inject] private EventManager _eventManager;

    private void Start()
    {
        _eventManager.Publish(new OpenScreenEvent("MainMenu"));
    }
}