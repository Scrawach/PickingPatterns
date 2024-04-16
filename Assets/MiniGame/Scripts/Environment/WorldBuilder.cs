using MiniGame.Scripts.Data;
using MiniGame.Scripts.Gameplay.Balls;
using MiniGame.Scripts.Gameplay.Balls.View;
using MiniGame.Scripts.Gameplay.Generators;

namespace MiniGame.Scripts.Environment
{
    public class WorldBuilder
    {
        private readonly BallRegistry _registry;
        private readonly StaticData _staticData;
        private readonly RandomLevelGenerator _generator;
        private readonly BallViewFactory _viewFactory;

        public WorldBuilder(BallRegistry registry, StaticData staticData, RandomLevelGenerator generator, BallViewFactory viewFactory)
        {
            _registry = registry;
            _staticData = staticData;
            _generator = generator;
            _viewFactory = viewFactory;
        }

        public void Build()
        {
            _staticData.Load();
            _generator.Generate();
        }

        public void Clear()
        {
            _registry.Clear();
            _viewFactory.Clear();
        }
    }
}