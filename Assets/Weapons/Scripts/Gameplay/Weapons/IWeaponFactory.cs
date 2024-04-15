using UnityEngine;

namespace Weapons.Gameplay.Weapons
{
    public interface IWeaponFactory
    {
        IWeapon Create(Transform shootPoint);
    }
}