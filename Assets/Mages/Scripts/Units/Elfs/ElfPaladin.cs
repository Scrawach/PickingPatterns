using UnityEngine;

namespace Mages.Units.Elfs
{
    public class ElfPaladin : MonoBehaviour, IPaladin
    {
        public void AttackTarget() => 
            Debug.Log($"Elf paladin attack target!");
    }
}