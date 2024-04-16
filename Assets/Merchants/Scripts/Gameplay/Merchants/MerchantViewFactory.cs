using Merchants.Tradings;
using UnityEngine;

namespace Merchants.Gameplay.Merchants
{
    public class MerchantViewFactory
    {
        private readonly MerchantAsset _asset;
        private readonly TradingFactory _tradingFactory;

        public MerchantViewFactory(MerchantAsset merchantAsset, TradingFactory tradingFactory)
        {
            _asset = merchantAsset;
            _tradingFactory = tradingFactory;
        }

        public MerchantView Create(Vector3 position)
        {
            var merchant = new Merchant(_tradingFactory);
            var instance = _asset.Instantiate(position, Quaternion.identity);
            instance.Construct(merchant);
            return instance;
        }
    }
}