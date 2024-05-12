using MiniGame.Scripts.Gameplay.Conditions;

namespace MiniGame.Scripts.SceneManagement
{
    public class SceneLoaderMediator
    {
        private readonly ISceneLoader _sceneLoader;

        public SceneLoaderMediator(ISceneLoader sceneLoader) => 
            _sceneLoader = sceneLoader;

        public void GoToMainMenu() => 
            _sceneLoader.Load(SceneName.MainMenu);

        public void GoToGameplay(ConditionType condition) => 
            _sceneLoader.Load(SceneName.Gameplay, condition);
    }
}