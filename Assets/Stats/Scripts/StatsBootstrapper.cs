using UnityEngine;

namespace Stats.Scripts
{
    public class StatsBootstrapper : MonoBehaviour
    {
        private void Start()
        {
            var statsFactory = new StatsFactory();
            
            Debug.Log($"{statsFactory.Create(RaceType.Human, SpecializationType.Mage, AbilityType.DexterityBust)}");
            Debug.Log($"{statsFactory.Create(RaceType.Elf, SpecializationType.Warrior, AbilityType.IntelligenceBust)}");
            Debug.Log($"{statsFactory.Create(RaceType.Orc, SpecializationType.Warrior, AbilityType.StrengthBust)}");
            Debug.Log($"{statsFactory.Create(RaceType.Orc, SpecializationType.Rogue, AbilityType.DexterityBust)}");
        }
    }
}