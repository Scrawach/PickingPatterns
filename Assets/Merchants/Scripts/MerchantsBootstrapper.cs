using Merchants.AssetManagement;
using Merchants.Gameplay.Merchants;
using Merchants.Gameplay.PlayerLogic;
using Merchants.Tradings;
using Merchants.Tradings.Policies;
using Merchants.UserInput;
using UnityEngine;

namespace Merchants
{
    public class MerchantsBootstrapper : MonoBehaviour
    {
        [SerializeField] private Transform _playerSpawnPoint;
        [SerializeField] private int _startReputation;
        [SerializeField] private Transform _merchantSpawnPoint;
        
        private void Start()
        {
            var assets = new ResourcesAssets();
            var playerFactory = CreatePlayerFactory(assets, _startReputation);
            var merchantFactory = CreateMerchantFactory(assets);

            playerFactory.Create(_playerSpawnPoint.position);
            merchantFactory.Create(_merchantSpawnPoint.position);
        }

        private static PlayerViewFactory CreatePlayerFactory(IAssets assets, int startReputation)
        {
            var unityInput = new KeyboardInput(Camera.main);
            var playerAsset = new PlayerAsset(assets);
            return new PlayerViewFactory(unityInput, playerAsset, startReputation);
        }
        
        private static MerchantViewFactory CreateMerchantFactory(IAssets assets)
        {
            var noTradingPolicy = new TradingPolicy(new NoTrading(), player => player.Reputation < 0);
            var fruitPolicy = new TradingPolicy(new FruitsTrading(), player => player.Reputation < 5);
            var armorPolicy = new TradingPolicy(new ArmorTrading(), player => player.Reputation >= 5);
            var tradingFactory = new TradingFactory(noTradingPolicy, fruitPolicy, armorPolicy);
            var merchantAsset = new MerchantAsset(assets);
            return new MerchantViewFactory(merchantAsset, tradingFactory);
        }
    }
}