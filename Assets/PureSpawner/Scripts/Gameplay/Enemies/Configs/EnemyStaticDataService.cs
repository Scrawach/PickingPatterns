using System.Collections.Generic;
using System.Linq;
using PureSpawner.Infrastructure.AssetManagement;

namespace PureSpawner.Gameplay.Enemies.Configs
{
    public class EnemyStaticDataService
    {
        private const string ConfigsPath = "Configs/Enemies";
        
        private readonly IAssets _assets;
        
        private Dictionary<EnemyType, EnemyConfig> _configs;

        public EnemyStaticDataService(IAssets assets) => 
            _assets = assets;

        public void Load() =>
            _configs = _assets
                .LoadAll<EnemyConfig>(ConfigsPath)
                .ToDictionary(key => key.EnemyType, value => value);

        public EnemyConfig GetFor(EnemyType enemyType) => 
            _configs[enemyType];
    }
}