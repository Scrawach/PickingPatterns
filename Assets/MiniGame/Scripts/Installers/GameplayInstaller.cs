using MiniGame.Scripts.AssetManagement;
using MiniGame.Scripts.CameraLogic;
using MiniGame.Scripts.Data;
using MiniGame.Scripts.Environment;
using MiniGame.Scripts.Gameplay.Balls;
using MiniGame.Scripts.Gameplay.Balls.View;
using MiniGame.Scripts.Gameplay.Conditions;
using MiniGame.Scripts.Gameplay.Generators;
using MiniGame.Scripts.Gameplay.Picker;
using MiniGame.Scripts.Random;
using MiniGame.Scripts.SceneManagement;
using MiniGame.Scripts.UI;
using MiniGame.Scripts.UI.Assets;
using MiniGame.Scripts.UserInput;
using Zenject;

namespace MiniGame.Scripts.Installers
{
    public class GameplayInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindInfrastructure();
            BindAssets();
            BindServices();
            BindFactories();
            
            BindEntryPoint();
        }

        private void BindInfrastructure()
        {
            Container.Bind<ZenjectSceneLoaderWrapper>().AsSingle();
            Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
            Container.Bind<SceneLoaderMediator>().AsSingle();
        }

        private void BindAssets()
        {
            Container.Bind<IAssets>().To<ResourcesAssets>().AsSingle();
            Container.Bind<SettingsAsset>().AsSingle();
            Container.Bind<BallAsset>().AsSingle();
            Container.Bind<BallPickerAsset>().AsSingle();
            Container.Bind<MainMenuPanelAsset>().AsSingle();
            Container.Bind<VictoryPanelAsset>().AsSingle();
        }

        private void BindServices()
        {
            Container.BindInterfacesAndSelfTo<WinCondition>().AsSingle();
            Container.BindInterfacesAndSelfTo<GameplayUI>().AsSingle();
            Container.Bind<CameraProvider>().AsSingle();
            Container.Bind<IInput>().To<UnityInput>().AsSingle();
            Container.Bind<StaticData>().AsSingle();
            Container.Bind<IRandom>().To<UnityRandom>().AsSingle();
            Container.Bind<RandomLevelGenerator>().AsSingle();
            Container.Bind<BallRegistry>().AsSingle();
            Container.Bind<WorldBuilder>().AsSingle();
            Container.Bind<MiniGame>().AsSingle();
        }

        private void BindFactories()
        {
            Container.Bind<BallPickerFactory>().AsSingle();
            Container.Bind<BallViewFactory>().AsSingle();
            Container.Bind<UIFactory>().AsSingle();
        }

        private void BindEntryPoint() => 
            Container.BindInterfacesAndSelfTo<GameplayLoop>().AsSingle().NonLazy();
    }
}