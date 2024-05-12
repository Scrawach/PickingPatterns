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
            BindAssets();
            BindServices();
            BindFactories();
            
            BindEntryPoint();
        }

        private void BindAssets()
        {
            Container.Bind<SettingsAsset>().AsSingle();
            Container.Bind<BallAsset>().AsSingle();
            Container.Bind<BallPickerAsset>().AsSingle();
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
        }

        private void BindEntryPoint() => 
            Container.BindInterfacesAndSelfTo<GameplayLoop>().AsSingle().NonLazy();
    }
}