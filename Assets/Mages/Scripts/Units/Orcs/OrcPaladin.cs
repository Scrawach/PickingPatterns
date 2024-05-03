using UnityEngine;

namespace Mages.Units.Orcs
{
    public class OrcPaladin : MonoBehaviour, IPaladin
    {
        public void AttackTarget() => 
            Debug.Log($"Orc paladin attack target!");
    }
}