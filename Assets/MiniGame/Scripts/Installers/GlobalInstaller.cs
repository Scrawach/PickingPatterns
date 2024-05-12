using MiniGame.Scripts.AssetManagement;
using MiniGame.Scripts.SceneManagement;
using MiniGame.Scripts.UI;
using MiniGame.Scripts.UI.Assets;
using Zenject;

namespace MiniGame.Scripts.Installers
{
    public class GlobalInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindSceneManagement();
            BindUIServices();
        }

        private void BindSceneManagement()
        {
            Container.Bind<ZenjectSceneLoaderWrapper>().AsSingle();
            Container.Bind<IAssets>().To<ResourcesAssets>().AsSingle();
            Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
            Container.Bind<SceneLoaderMediator>().AsSingle();
        }

        private void BindUIServices()
        {
            Container.Bind<VictoryPanelAsset>().AsSingle();
            Container.Bind<MainMenuPanelAsset>().AsSingle();
            Container.Bind<UIFactory>().AsSingle();
        }
    }
}