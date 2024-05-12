using MiniGame.Scripts.UI;
using Zenject;

namespace MiniGame.Scripts.Installers
{
    public class MainMenuInstaller : MonoInstaller
    {
        public override void InstallBindings() => 
            Container.BindInterfacesAndSelfTo<MainMenuUI>().AsSingle().NonLazy();
    }
}