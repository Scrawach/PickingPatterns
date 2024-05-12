using MiniGame.Scripts.Gameplay.Conditions;
using MiniGame.Scripts.UI;

namespace MiniGame.Scripts.SceneManagement
{
    public class SceneLoader : ISceneLoader
    {
        private readonly ZenjectSceneLoaderWrapper _sceneLoader;

        public SceneLoader(ZenjectSceneLoaderWrapper sceneLoader) => 
            _sceneLoader = sceneLoader;

        public void Load(int sceneId, ConditionType condition)
        {
            _sceneLoader.Load(sceneId, container =>
            {
                container.Bind<WinConditionProvider>().FromInstance(new WinConditionProvider(condition)).AsSingle();
            });
        }

        public void Load(int sceneId) => 
            _sceneLoader.Load(sceneId);
    }
}