using UnityEngine;

namespace Mages.Units.Orcs
{
    public class OrcMage : MonoBehaviour, IMage
    {
        public void CastSpell() => 
            Debug.Log($"Orc mage cast spell!");
    }
}