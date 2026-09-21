using Gameplay;
using Zenject;

public class CoreSceneInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<PauseInputHandler>()
            .FromNewComponentOnNewGameObject()
            .AsSingle()
            .NonLazy();
    }
}