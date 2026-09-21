using Core.SceneManagement;
using Gameplay;
using UnityEngine;
using Zenject;

public class CoreProjectInstaller : MonoInstaller
{
    [SerializeField] private UIController _uiController;
    [SerializeField] private PauseView _pauseView;

    public override void InstallBindings()
    {
        Container.Bind<EventManager>().AsSingle();
        Container.Bind<UIController>().FromInstance(_uiController).AsSingle();
        Container.Bind<SceneTransitionService>().AsSingle().NonLazy();
        Container.Bind<GameState>().AsSingle().NonLazy();
        Container.Bind<PauseView>().FromInstance(_pauseView).AsSingle();
        Container.Bind<PauseController>().AsSingle();
    }
}
