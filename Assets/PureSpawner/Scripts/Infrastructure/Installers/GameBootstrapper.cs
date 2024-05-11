using Zenject;

namespace PureSpawner.Infrastructure.Installers
{
    public class GameBootstrapper : IInitializable
    {
        private readonly Game _game;

        public GameBootstrapper(Game game) => 
            _game = game;

        public void Initialize() => 
            _game.Start();
    }
}