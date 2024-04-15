namespace Weapons.Gameplay.Weapons
{
    public interface IWeapon
    {
        bool HasAmmo();
        void AddAmmo(int amountOfAmmo);
        void Shoot();
    }
}