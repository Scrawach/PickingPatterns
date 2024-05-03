using Mages.AssetManagement;
using UnityEngine;

namespace Mages.Units.Elfs
{
    public class ElfUnitFactory : IUnitFactory
    {
        private const string ElfPaladinPath = "Elves/Paladin";
        private const string ElfMagePath = "Elves/Mage";

        private readonly InstantiateFactory _factory;

        public ElfUnitFactory(InstantiateFactory factory) => 
            _factory = factory;
        
        public IMage CreateMage(Vector3 position) => 
            _factory.Instantiate<ElfMage>(ElfMagePath, position, Quaternion.identity, null);

        public IPaladin CreatePaladin(Vector3 position) => 
            _factory.Instantiate<ElfPaladin>(ElfPaladinPath, position, Quaternion.identity, null);
    }
}