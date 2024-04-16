using Merchants.UserInput;
using UnityEngine;

namespace Merchants.Gameplay.PlayerLogic
{
    public class PlayerViewFactory
    {
        private readonly IInput _input;
        private readonly PlayerAsset _asset;
        private readonly int _startReputation;

        public PlayerViewFactory(IInput input, PlayerAsset asset, int startReputation)
        {
            _input = input;
            _asset = asset;
            _startReputation = startReputation;
        }

        public PlayerView Create(Vector3 position)
        {
            var instance = _asset.Instantiate(position, Quaternion.identity);
            var player = new Player(new Reputation(_startReputation));
            instance.Construct(_input, player);
            return instance;
        }
    }
}