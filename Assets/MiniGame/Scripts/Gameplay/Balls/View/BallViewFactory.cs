using MiniGame.Scripts.Data;
using UnityEngine;

namespace MiniGame.Scripts.Gameplay.Balls.View
{
    public class BallViewFactory
    {
        private readonly BallRegistry _registry;
        private readonly BallAsset _asset;
        private readonly StaticData _staticData;

        public BallViewFactory(BallRegistry registry, BallAsset asset, StaticData staticData)
        {
            _registry = registry;
            _asset = asset;
            _staticData = staticData;
        }

        public BallView Create(BallType type, Vector3 position)
        {
            var instance = _asset.Instantiate(position, Quaternion.identity);
            var typeMaterial = _staticData.GetMaterialByType(type);
            var ball = new Ball(type);
            _registry.Add(ball);
            instance.Construct(ball, typeMaterial);
            return instance;
        }
    }
}