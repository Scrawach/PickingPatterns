using Mages.Units;
using UnityEngine;

namespace Mages
{
    public class PlayerInput : MonoBehaviour
    {
        private SwitchingUnitFactory _switchingUnitFactory;
        
        public void Construct(SwitchingUnitFactory switchingFactory) => 
            _switchingUnitFactory = switchingFactory;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Debug.Log($"Switch race for factory!");
                _switchingUnitFactory.Switch();
            }
        }
    }
}