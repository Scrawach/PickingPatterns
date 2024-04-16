using System.Collections.Generic;
using MiniGame.Scripts.Data;
using MiniGame.Scripts.Gameplay.Balls;
using MiniGame.Scripts.Gameplay.Balls.View;
using MiniGame.Scripts.Random;
using UnityEngine;

namespace MiniGame.Scripts.Gameplay.Generators
{
    public class RandomLevelGenerator
    {
        private readonly BallViewFactory _factory;
        private readonly StaticData _staticData;
        private readonly IRandom _random;

        public RandomLevelGenerator(BallViewFactory factory, StaticData staticData, IRandom random)
        {
            _factory = factory;
            _staticData = staticData;
            _random = random;
        }

        public void Generate()
        {
            var availableMaterials = _staticData.AllMaterials();
            var levelData = _staticData.GetGeneratorData();

            for (var i = 0; i < levelData.AmountOfBalls; i++)
            {
                var randomPosition = GetRandomPosition(levelData);
                var randomType = GetRandomBallType(availableMaterials);
                _factory.Create(randomType, randomPosition);
            }
        }

        private Vector3 GetRandomPosition(LevelGeneratorData levelData)
        {
            var randomCircle = _random.InsideUnitCircle(levelData.FieldRadius); 
            var randomPosition = levelData.Center + new Vector3(randomCircle.x, 0, randomCircle.y);
            return randomPosition;
        }

        private BallType GetRandomBallType(IReadOnlyList<BallMaterial> materials)
        {
            var randomTypeIndex = _random.Range(0, materials.Count);
            var randomType = materials[randomTypeIndex];
            return randomType.Type;
        }
    }
}