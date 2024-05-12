using MiniGame.Scripts.AssetManagement;
using MiniGame.Scripts.SceneManagement;
using MiniGame.Scripts.UI;
using MiniGame.Scripts.UI.Assets;
using Zenject;

namespace MiniGame.Scripts.Installers
{
    public class MainMenuInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ZenjectSceneLoaderWrapper>().AsSingle();
            Container.Bind<IAssets>().To<ResourcesAssets>().AsSingle();
            Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
            Container.Bind<SceneLoaderMediator>().AsSingle();
            Container.Bind<VictoryPanelAsset>().AsSingle();
            Container.Bind<MainMenuPanelAsset>().AsSingle();
            Container.Bind<UIFactory>().AsSingle();
            
            Container.BindInterfacesAndSelfTo<MainMenuUI>().AsSingle().NonLazy();
        }
    }
}