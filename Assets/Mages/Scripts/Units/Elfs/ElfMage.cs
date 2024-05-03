using UnityEngine;

namespace Mages.Units.Elfs
{
    public class ElfMage : MonoBehaviour, IMage
    {
        public void CastSpell() => 
            Debug.Log($"Elf mage cast spell!");
    }
}