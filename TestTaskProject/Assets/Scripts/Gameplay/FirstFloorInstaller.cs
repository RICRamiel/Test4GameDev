using Zenject;
using Gameplay;

public class FirstFloorInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<FirstFloorSetup>()
            .FromComponentInHierarchy()
            .AsSingle();

        Container.BindInterfacesAndSelfTo<FirstFloorController>().AsSingle().NonLazy();
    }
}