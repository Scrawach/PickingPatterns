using System.Collections.Generic;
using MiniGame.Scripts.Data;
using MiniGame.Scripts.Gameplay.Balls;
using MiniGame.Scripts.Gameplay.Balls.View;
using UnityEngine;

namespace MiniGame.Scripts.Gameplay.Generators
{
    public class RandomLevelGenerator
    {
        private readonly BallViewFactory _factory;
        private readonly StaticData _staticData;

        public RandomLevelGenerator(BallViewFactory factory, StaticData staticData)
        {
            _factory = factory;
            _staticData = staticData;
        }

        public void Generate()
        {
            var availableMaterials = _staticData.AllMaterials();
            var levelData = _staticData.GetGeneratorData();

            for (var i = 0; i < levelData.AmountOfBalls; i++)
            {
                var randomCircle = Random.insideUnitCircle * levelData.FieldRadius;
                var randomPosition = levelData.Center + new Vector3(randomCircle.x, 0, randomCircle.y);
                var randomType = GetRandomBallType(availableMaterials);
                _factory.Create(randomType, randomPosition);
            }
        }

        private static BallType GetRandomBallType(IReadOnlyList<BallMaterial> materials)
        {
            var randomTypeIndex = Random.Range(0, materials.Count);
            var randomType = materials[randomTypeIndex];
            return randomType.Type;
        }
    }
}