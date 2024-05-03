using Mages.Units.Elfs;
using Mages.Units.Orcs;
using UnityEngine;

namespace Mages.Units
{
    public class SwitchingUnitFactory : IUnitFactory
    {
        private readonly OrcUnitFactory _orcFactory;
        private readonly ElfUnitFactory _elfFactory;

        private IUnitFactory _current;
        
        public SwitchingUnitFactory(OrcUnitFactory orcFactory, ElfUnitFactory elfFactory)
        {
            _orcFactory = orcFactory;
            _elfFactory = elfFactory;
            _current = _orcFactory;
        }

        public void Switch() => 
            _current = _current == _orcFactory 
                ? _elfFactory 
                : _orcFactory;

        public IMage CreateMage(Vector3 position) => 
            _current.CreateMage(position);

        public IPaladin CreatePaladin(Vector3 position) => 
            _current.CreatePaladin(position);
    }
}