using Zenject;

namespace Gameplay.SecondFloor
{
    public class SecondFloorInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<SecondFloorController>()
                .AsSingle()
                .NonLazy();
        }
    }
}