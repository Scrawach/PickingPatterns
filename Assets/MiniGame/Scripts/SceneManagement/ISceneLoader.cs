using MiniGame.Scripts.Gameplay.Conditions;

namespace MiniGame.Scripts.SceneManagement
{
    public interface ISceneLoader
    {
        void Load(int sceneId);
        void Load(int sceneId, ConditionType condition);
    }
}