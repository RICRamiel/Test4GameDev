using Gameplay;
using Zenject;

public class CoreSceneInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<FirstFloorSetup>()
            .FromComponentInHierarchy()
            .AsSingle();
        
        Container.Bind<FirstFloorController>().AsSingle().NonLazy();
    }
}
