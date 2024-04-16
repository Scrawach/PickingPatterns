using System.Collections.Generic;
using MiniGame.Scripts.Data;
using UnityEngine;

namespace MiniGame.Scripts.Gameplay.Balls.View
{
    public class BallViewFactory
    {
        private readonly BallRegistry _registry;
        private readonly BallAsset _asset;
        private readonly StaticData _staticData;

        private readonly List<BallView> _views;

        public BallViewFactory(BallRegistry registry, BallAsset asset, StaticData staticData)
        {
            _registry = registry;
            _asset = asset;
            _staticData = staticData;
            _views = new List<BallView>();
        }

        public BallView Create(BallType type, Vector3 position)
        {
            var instance = _asset.Instantiate(position, Quaternion.identity);
            var typeMaterial = _staticData.GetMaterialByType(type);
            var ball = new Ball(type);
            _registry.Add(ball);
            instance.Construct(this, ball, typeMaterial);
            _views.Add(instance);
            return instance;
        }

        public void Destroy(BallView view)
        {
            _views.Remove(view);
            Object.Destroy(view.gameObject);
        }

        public void Clear()
        {
            foreach (var view in _views) 
                Object.Destroy(view.gameObject);
            _views.Clear();
        }
    }
}