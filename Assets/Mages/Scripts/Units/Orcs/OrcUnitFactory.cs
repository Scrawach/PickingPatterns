using Mages.AssetManagement;
using UnityEngine;

namespace Mages.Units.Orcs
{
    public class OrcUnitFactory : IUnitFactory
    {
        private const string OrcPaladinPath = "Orcs/Paladin";
        private const string OrcMagePath = "Orcs/Mage";

        private readonly InstantiateFactory _factory;

        public OrcUnitFactory(InstantiateFactory factory) => 
            _factory = factory;

        
        public IMage CreateMage(Vector3 position) => 
            _factory.Instantiate<OrcMage>(OrcMagePath, position, Quaternion.identity, null);

        public IPaladin CreatePaladin(Vector3 position) => 
            _factory.Instantiate<OrcPaladin>(OrcPaladinPath, position, Quaternion.identity, null);
    }
}