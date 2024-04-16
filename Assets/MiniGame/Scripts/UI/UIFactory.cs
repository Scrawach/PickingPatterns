using MiniGame.Scripts.Gameplay.Conditions;
using UnityEngine;

namespace MiniGame.Scripts.UI
{
    public class UIFactory
    {
        private readonly UIRootAsset _asset;
        private readonly MiniGame _game;
        private readonly SelectedCondition _condition;

        public UIFactory(UIRootAsset asset, MiniGame game, SelectedCondition condition)
        {
            _asset = asset;
            _game = game;
            _condition = condition;
        }

        public UIRoot CreateUIRoot()
        {
            var instance = _asset.Instantiate(Vector3.zero, Quaternion.identity);
            instance.Construct(_condition, _game);
            return instance;
        }
    }
}