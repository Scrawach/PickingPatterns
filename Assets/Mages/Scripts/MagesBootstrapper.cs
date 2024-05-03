using Mages.AssetManagement;
using Mages.Units;
using Mages.Units.Elfs;
using Mages.Units.Orcs;
using UnityEngine;

namespace Mages
{
    public class MagesBootstrapper : MonoBehaviour
    {
        [SerializeField] private Spawner _spawner;
        [SerializeField] private PlayerInput _input;

        private void Start()
        {
            var assets = new Assets();
            var instatiator = new InstantiateFactory(assets);
            var orcFactory = new OrcUnitFactory(instatiator);
            var elfFactory = new ElfUnitFactory(instatiator);
            var switchingUnitFactory = new SwitchingUnitFactory(orcFactory, elfFactory);
            
            _spawner.Construct(switchingUnitFactory);
            _input.Construct(switchingUnitFactory);
            
            _spawner.StartSpawning();
        }
    }
}